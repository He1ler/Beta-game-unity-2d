// Script for main menu
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour
{
    public void Play()// For button "New game" starting new game
    {
        GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().NewData();
        GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().SaveLevelName("Hub location");
        GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().LoadOrNewGame(false, true);
        SceneManager.LoadScene("Loading");
    }
    public void Continue()
    {
        GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().LoadOrNewGame(true,false);
        GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().TransitDataToCurrent();
        SceneManager.LoadScene("Loading");
    }
    public void Exit()
    {
        GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().SaveDataIntoFile();
        Pausemenu.Exit();
    }
    public void MainMenu()// Button which load main menu
    {
        Time.timeScale = 1;
        GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().SaveDataIntoFile();
        Pausemenu.GameisPaused = false;
        SceneManager.LoadScene("Main menu");
    }
}
