using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pausemenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject PausemenuUI;
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Pause()
    {
        GameisPaused = true;
        PausemenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        GameisPaused = false;
        PausemenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
