using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class HeroSelector : MonoBehaviour
{
    public int heroSelect1 = 0;
    public int heroSelect2 = 0;
    public string MapName;

    public Button button1;
    public Button button2;
    public Button startbutton;

    private Sprite spr;
        
    private Button savebtn1;
    private Button savebtn2;

    private int index = 0;
    void Update ()
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
     public void Indexplus(Button btn)
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
    public void indexminus(Button btn)
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
    public void MapNameToFile()
    {
        DataTransition.MapNameToFile(this);
    }
    public void SetMapname(Button btn)
    {
        MapName = btn.name;
    }
    public void StartLevel()
    {
        SceneManager.LoadScene("Loading");
    }
}
