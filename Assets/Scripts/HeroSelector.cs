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
            button1.image = btn.image;
            btn.gameObject.SetActive(false);
            heroSelect1 = Convert.ToInt32(btn.name);
        }
        else if (index == 2)
        {
            button2.gameObject.SetActive(true);
            btn.gameObject.SetActive(false);
            button2.image = btn.image;
            heroSelect2 = Convert.ToInt32(btn.name);
        }
    }
    public void indexminus()
    {
        index--;
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
