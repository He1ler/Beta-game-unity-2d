// Script for main menu
using UnityEngine;
using UnityEngine.SceneManagement;
using static DataTransition;
public class Mainmenu : MonoBehaviour
{
    public void Play()// For button "New game" starting new game
    {
        MapNameToFileMenu("Hub location");
        SceneManager.LoadScene("Loading");
    }
    public void Continue()
    {
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
