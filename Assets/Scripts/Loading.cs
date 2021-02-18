using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    public IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(3.0f);
        LoadLevel();
    }
    public void LoadLevel ()
    {
        StartCoroutine(LoadingAsync(DataTransition.MapNameFromFile().mapName));
    }
    IEnumerator LoadingAsync (string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
                yield return null;
        }
    }
}
