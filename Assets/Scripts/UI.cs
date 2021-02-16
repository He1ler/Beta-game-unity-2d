using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    Loading nextscene;

    public static bool GameIsOver;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    private bool dead1 = false;
    private bool dead2 = false;

  //  private Player hero1;
  //  private Player hero2;

    private string MapName;
    void Start()
    {
        GameIsOver = false;
    }
    // Update is called once per frame
    void Update()
    {
      //  dead1 = hero1.IsDeadHero;
      // dead2 = hero2.IsDeadHero;
        if (dead1 && dead2)
        {
            LoseLevel();
        }
        if (GameIsOver)
            return;
    }
    public void LoseLevel()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
    public void SetMapname(Button btn)
    {
        MapName = btn.name;
    }
    public void StartLevel()
    {
        SceneManager.LoadScene("Loading");
        nextscene.LoadLevel(MapName);
    }
}
