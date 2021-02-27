using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
public enum BattleState { Waiting, Hero1, Hero2, Enemy1, Enemy2, Enemy3, Enemy4 };
public class UI : MonoBehaviour
{
    public WaveSpawnerScript wavespawner;
    public BattleState turns;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    public Slider hero1Slider;
    public Slider hero2Slider;
    public Slider enemy1Slider;
    public Slider enemy2Slider;
    public Slider enemy3Slider;
    public Slider enemy4Slider;

    public TMP_Text hero1HPText;
    public TMP_Text hero2HPText;
    public TMP_Text enemy1HPText;
    public TMP_Text enemy2HPText;
    public TMP_Text enemy3HPText;
    public TMP_Text enemy4HPText;

    public Button hero1Btn;
    public Button hero2Btn;
    public TMP_Text Hero1Name;
    public TMP_Text Hero2Name;

    public Button skill1;
    public Button skill2;
    public Button skill3;
    public Button skill4;
    void Start ()
    {
        StartCoroutine(StartingHUD());
    }
    IEnumerator StartingHUD()
    {
        yield return new WaitForSeconds(0.1f);
        turns = BattleState.Waiting;
        hero1Btn.image.sprite = wavespawner.hero1.HeroImage;
        hero2Btn.image.sprite = wavespawner.hero2.HeroImage;
        /*skill1.image = wavespawner.hero1.Skill1Image;
        skill2.image = wavespawner.hero1.Skill2Image;
        skill3.image = wavespawner.hero1.Skill3Image;
        skill4.image = wavespawner.hero1.Skill4Image;*/
        Hero1Name.text = wavespawner.hero1.HeroName;
        Hero2Name.text = wavespawner.hero2.HeroName;
        hero1Slider.value = wavespawner.hero1.health / wavespawner.hero1.MaxHealth;
        hero2Slider.value = wavespawner.hero2.health / wavespawner.hero2.MaxHealth;
        enemy1Slider.value = wavespawner.enemy1.health / wavespawner.enemy1.MaxHealth;
        enemy2Slider.value = wavespawner.enemy2.health / wavespawner.enemy2.MaxHealth;
        enemy3Slider.value = wavespawner.enemy3.health / wavespawner.enemy3.MaxHealth;
        enemy4Slider.value = wavespawner.enemy4.health / wavespawner.enemy4.MaxHealth;

        hero1HPText.text = Convert.ToString(wavespawner.hero1.health) + " / " + Convert.ToString(wavespawner.hero1.MaxHealth);
        hero2HPText.text = Convert.ToString(wavespawner.hero2.health) + " / " + Convert.ToString(wavespawner.hero1.MaxHealth);
        enemy1HPText.text = Convert.ToString(wavespawner.enemy1.health) + " / " + Convert.ToString(wavespawner.hero1.MaxHealth);
        enemy2HPText.text = Convert.ToString(wavespawner.enemy2.health) + " / " + Convert.ToString(wavespawner.hero1.MaxHealth);
        enemy3HPText.text = Convert.ToString(wavespawner.enemy3.health) + " / " + Convert.ToString(wavespawner.hero1.MaxHealth);
        enemy4HPText.text = Convert.ToString(wavespawner.enemy4.health) + " / " + Convert.ToString(wavespawner.hero1.MaxHealth);
    }
    public void LoseLevel()
    {
        gameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        completeLevelUI.SetActive(true);
    }
}
