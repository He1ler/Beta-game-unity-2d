using UnityEngine;
using UnityEngine.SceneManagement;
using static DataTransition;
public class Mainmenu : MonoBehaviour
{
    public void Play()
    {
        MapNameToFileMenu("Hub location");
        SceneManager.LoadScene("Loading");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        Pausemenu.GameisPaused = false;
        SceneManager.LoadScene("Main menu");
    }
}
