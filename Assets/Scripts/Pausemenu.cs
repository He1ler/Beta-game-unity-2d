// Script for pause window
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject PausemenuUI;
    public GameObject SettingsUI;
    public GameObject PausepanelUI;
    public GameObject Sound;
    private AudioSource Audio;
    void Start()
    {
        Time.timeScale = 1;
        Audio = Sound.GetComponent<AudioSource>();
    }
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))//pausing game if press ESC, and unpause if press it again
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
        PausepanelUI.SetActive(true);
        Time.timeScale = 0f;
        Audio.Pause();
    }
    public void Resume()
    {
        GameisPaused = false;
        SettingsUI.SetActive(false);
        PausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        Audio.UnPause();
    }
    public static void Exit()
    {
        Application.Quit();
    }
}
