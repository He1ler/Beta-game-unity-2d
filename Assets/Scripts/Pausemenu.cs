using UnityEngine;
using UnityEngine.Audio;
public class Pausemenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject PausemenuUI;
    public GameObject SettingsUI;
    public GameObject PausepanelUI;
    public GameObject Sound;
    private AudioSource audio;
    void Start()
    {
        audio = Sound.GetComponent<AudioSource>();
    }
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
        PausepanelUI.SetActive(true);
        Time.timeScale = 0f;
        audio.Pause();
    }
    public void Resume()
    {
        GameisPaused = false;
        SettingsUI.SetActive(false);
        PausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        audio.UnPause();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
