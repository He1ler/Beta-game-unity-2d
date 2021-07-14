// Script for Loading mechanic in game
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Slider slider;
    public IEnumerator Start()//forcing Coroutining of fuction which load level
    {
        yield return new WaitForSecondsRealtime(3.0f);
        LoadLevel();
    }
    public void LoadLevel ()
    {
        StartCoroutine(LoadingAsync(DataTransition.MapNameFromFile().mapName));
    }
    IEnumerator LoadingAsync (string scene)//copying Level name to function and load propper level and copuing progress of loading to Load Screen slider
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            if (progress >= 0.1f)
            { slider.value = progress; }
                yield return null;
        }
    }
}
