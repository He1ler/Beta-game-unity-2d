// Script for Screen of choosing hero and level int hub location
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class HeroSelector : MonoBehaviour
{
    public int heroSelect1 = 0;
    public int heroSelect2 = 0;
    public bool Isboss = false;
    public string MapName;

    public Button button1;
    public Button button2;
    public Button startbutton;

    private Sprite spr;
        
    private Button savebtn1;
    private Button savebtn2;

    private int index = 0;
    void Update ()//activating button "Play" in the screen of choosing heroes when you pick 2 heroes
    {
    if (index==2)
        {
            startbutton.gameObject.SetActive(true);
        }
        else
        {
            startbutton.gameObject.SetActive(false);
        }
    }
     public void Indexplus(Button btn)// If you pick hero rise counter and save hero you have choosen
     {
        index++;
        if (index == 1)
        {
            button1.gameObject.SetActive(true);
            button1.image.sprite = btn.image.sprite;
            btn.gameObject.SetActive(false);
            heroSelect1 = Convert.ToInt32(btn.name);
            savebtn1= btn;
        }
        else if (index == 2)
        {
            button2.gameObject.SetActive(true);
            btn.gameObject.SetActive(false);
            button2.image.sprite = btn.image.sprite;
            heroSelect2 = Convert.ToInt32(btn.name);
            savebtn2 = btn;
        }
    }
    public void indexminus(Button btn)// if you cancel picking of hero decrease counter and delete saved data of hero
    {
        if (index == 1)
        {
            savebtn1.gameObject.SetActive(true);
        }
        else if (index == 2)
        {
            savebtn2.gameObject.SetActive(true);
        }
        index--;
        btn.image.sprite = spr;
        btn.gameObject.SetActive(false);
        
    }
    public void MapNameToFile()// saving Level name in file for loading
    {
        DataTransition.MapNameToFile(this);
    }
    public void SetMapname(Button btn)// Choosing Level
    {
        MapName = btn.name;
    }
    public void StartLevel()
    {
        DataTransition.IsLoadToFileMenu(false,false);
        SceneManager.LoadScene("Loading");
    }
    public void SetBossTrue()// If you choos boss location boolean will load settings for boss levels
    {
        Isboss = true;
    }
}
