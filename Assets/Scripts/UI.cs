using System;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    //public Button buttonAccept;
   // private int index = 0;

    private bool dead1 = false;
    private bool dead2 = false;

    public int[] Hero;
    private Player hero1;
    private Player hero2;

    private string MapName;
    void Start()
    {
        GameIsOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        dead1 = hero1.IsDeadHero;
        dead2 = hero2.IsDeadHero;
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
   /* public void Indexplus()
    {
        Hero[index] = Convert.ToInt32(buttonAccept.image.name);
        index++;
    }
    public void indexminus()
    {
        Hero[index] = 8;
        index--;
    }*/
}
