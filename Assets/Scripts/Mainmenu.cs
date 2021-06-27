// Script for main menu
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour
{
    public void Play()// For button "New game" starting new game
    {
        DataTransition.MapNameToFileMenu("Hub location");
        DataTransition.IsLoadToFileMenu(false,true);
        SceneManager.LoadScene("Loading");
    }
    public void Continue()
    {
        DataTransition.IsLoadToFileMenu(true,false);
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
