using UnityEngine;
using UnityEngine.UI;
using System;

public class HeroSelector : MonoBehaviour
{
    public int[] Hero;
    public Button buttonAccept;
    private int index = 0;
     public void Indexplus()
 {
     Hero[index] = Convert.ToInt32(buttonAccept.image.name);
     index++;
 }
 public void indexminus()
 {
     Hero[index] = 8;
     index--;
 }
}
