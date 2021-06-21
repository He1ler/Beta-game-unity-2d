// Script for main menu
using UnityEngine;
using UnityEngine.SceneManagement;
using static DataTransition;
public class Mainmenu : MonoBehaviour
{
    public void Play()// Button play loades level
    {
        MapNameToFileMenu("Hub location");
        SceneManager.LoadScene("Loading");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void MainMenu()// Button which load main menu
    {
        Time.timeScale = 1;
        Pausemenu.GameisPaused = false;
        SceneManager.LoadScene("Main menu");
    }
}
