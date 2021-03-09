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
    bool[] CheckIsEnemiesDead = {false,false,false,false};
    static int EnemiesAlive;

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

    Player hero1;
    Player hero2;
    Monsterscript enemy1;
    Monsterscript enemy2;
    Monsterscript enemy3;
    Monsterscript enemy4;

    void Start ()
    {     
        StartCoroutine(StartingHUD());
    }
    void Update()
    {
        HPCheck();
    }
    IEnumerator StartingHUD()
    {
        yield return new WaitForSeconds(0.1f);
        hero1Btn.image.sprite = wavespawner.hero1.HeroImage;
        hero2Btn.image.sprite = wavespawner.hero2.HeroImage;

        Hero1Name.text = wavespawner.hero1.HeroName;
        Hero2Name.text = wavespawner.hero2.HeroName;

        hero1Btn.enabled = false;
        Hero1Name.enabled = false;
        hero2Btn.enabled = false;
        Hero2Name.enabled = false;

        hero1 = GameObject.Find(wavespawner.hero1.HeroName + "(Clone)").GetComponent<Player>();
        hero2 = GameObject.Find(wavespawner.hero2.HeroName + "(Clone)").GetComponent<Player>();
        enemy1 = GameObject.Find(wavespawner.enemy1.EnemyName + "(Clone)").GetComponent<Monsterscript>();
        enemy2 = GameObject.Find(wavespawner.enemy2.EnemyName + "(Clone)").GetComponent<Monsterscript>();
        if(wavespawner.EnemiesAlive>=3)
        {
            enemy3 = GameObject.Find(wavespawner.enemy3.EnemyName + "(Clone)").GetComponent<Monsterscript>();
        }
        if (wavespawner.EnemiesAlive >= 4)
        {
            enemy4 = GameObject.Find(wavespawner.enemy4.EnemyName + "(Clone)").GetComponent<Monsterscript>();
        }
        // skill1.image = wavespawner.hero1.Skill1Image;
        // skill2.image = wavespawner.hero1.Skill2Image;
        // skill3.image = wavespawner.hero1.Skill3Image;
        // skill4.image = wavespawner.hero1.Skill4Image;

        HPCheck();
        EnemiesAlive = wavespawner.EnemiesAlive;

        turns = BattleState.Waiting;
        StartCoroutine(BattleStart());
    }
    void LoseLevel()
    {
        gameOverUI.SetActive(true);
    }
    void WinLevel()
    {
        completeLevelUI.SetActive(true);
    }
    void HPCheck()
    {
        hero1Slider.value = wavespawner.hero1.health / wavespawner.hero1.MaxHealth;
        hero2Slider.value = wavespawner.hero2.health / wavespawner.hero2.MaxHealth;
        enemy1Slider.value = wavespawner.enemy1.health / wavespawner.enemy1.MaxHealth;
        enemy2Slider.value = wavespawner.enemy2.health / wavespawner.enemy2.MaxHealth;
        enemy3Slider.value = wavespawner.enemy3.health / wavespawner.enemy3.MaxHealth;
        enemy4Slider.value = wavespawner.enemy4.health / wavespawner.enemy4.MaxHealth;

        hero1HPText.text = Convert.ToString(wavespawner.hero1.health) + " / " + Convert.ToString(wavespawner.hero1.MaxHealth);
        hero2HPText.text = Convert.ToString(wavespawner.hero2.health) + " / " + Convert.ToString(wavespawner.hero2.MaxHealth);
        enemy1HPText.text = Convert.ToString(wavespawner.enemy1.health) + " / " + Convert.ToString(wavespawner.enemy1.MaxHealth);
        enemy2HPText.text = Convert.ToString(wavespawner.enemy2.health) + " / " + Convert.ToString(wavespawner.enemy2.MaxHealth);
        enemy3HPText.text = Convert.ToString(wavespawner.enemy3.health) + " / " + Convert.ToString(wavespawner.enemy3.MaxHealth);
        enemy4HPText.text = Convert.ToString(wavespawner.enemy4.health) + " / " + Convert.ToString(wavespawner.enemy4.MaxHealth);
    }
    IEnumerator BattleStart()
    {
        yield return new WaitForSeconds(1f);

        StartCoroutine(Hero1());
    }

    IEnumerator Hero1()
    {
        turns = BattleState.Hero1;
        hero1Btn.enabled = true;
        Hero1Name.enabled = true;
       // skill1.image = wavespawner.hero1.Skill1Image;
       // skill2.image = wavespawner.hero1.Skill2Image;
       // skill3.image = wavespawner.hero1.Skill3Image;
       //skill4.image = wavespawner.hero1.Skill4Image;

        yield return new WaitForSeconds(3f);
    }
    public void FromHero1()
    {
        if (turns == BattleState.Hero1)
        {
            CheckIfEnemiesDead();
            StartCoroutine(Hero2());
        }
    }
    IEnumerator Hero2()
    {
        yield return new WaitForSeconds(1f);
        turns = BattleState.Hero2;
        hero1Btn.enabled = false;
        Hero1Name.enabled = false;
        hero2Btn.enabled = true;
        Hero2Name.enabled = true;
        // skill1.image = wavespawner.hero2.Skill1Image;
        // skill2.image = wavespawner.hero2.Skill2Image;
        // skill3.image = wavespawner.hero2.Skill3Image;
        // skill4.image = wavespawner.hero2.Skill4Image;

        yield return new WaitForSeconds(3f);
    }
    public void FromHero2()
    {
        if (turns == BattleState.Hero2)
        {
            CheckIfEnemiesDead();
            StartCoroutine(Enemy1());
        }
    }
    IEnumerator Enemy1()
    {
        yield return new WaitForSeconds(5f);
        turns = BattleState.Enemy1;
        hero2Btn.enabled = false;
        Hero2Name.enabled = false;
        enemy1.Set_Attack();

        CheckIfEHeroesDead();

        StartCoroutine(Enemy2());
    }
    IEnumerator Enemy2()
    {
        yield return new WaitForSeconds(5f);
        turns = BattleState.Enemy2;
        enemy2.Set_Attack();

        CheckIfEHeroesDead();
        if (wavespawner.EnemiesAlive>=3)
        {
            StartCoroutine(Enemy3());
        }
        else
        {
            StartCoroutine(Hero1());
        }
    }
    IEnumerator Enemy3()
    {
        yield return new WaitForSeconds(5f);
        turns = BattleState.Enemy3;
        enemy3.Set_Attack();

        CheckIfEHeroesDead();
        if (wavespawner.EnemiesAlive >= 3)
        {
            StartCoroutine(Enemy4());
        }
        else
        {
            StartCoroutine(Hero1());
        }
    }
    IEnumerator Enemy4()
    {
        yield return new WaitForSeconds(5f);
        turns = BattleState.Enemy4;
        enemy4.Set_Attack();

        CheckIfEHeroesDead();

        turns = BattleState.Hero1;
        StartCoroutine(Hero1());
    }
    void CheckIfEnemiesDead()
    {
        if(wavespawner.enemy1.EnemyState == EnemyStates.Dead && !CheckIsEnemiesDead[0])
        {
            CheckIsEnemiesDead[0] = true;
            wavespawner.EnemiesAlive--;
        }
        if (wavespawner.enemy2.EnemyState == EnemyStates.Dead && !CheckIsEnemiesDead[1] && EnemiesAlive == 2)
        {
            CheckIsEnemiesDead[1] = true;
            wavespawner.EnemiesAlive--;
        }
        if (wavespawner.enemy3.EnemyState == EnemyStates.Dead && !CheckIsEnemiesDead[2] && EnemiesAlive==3)
        {
            CheckIsEnemiesDead[2] = true;
            wavespawner.EnemiesAlive--;
        }
        if (wavespawner.enemy4.EnemyState == EnemyStates.Dead && !CheckIsEnemiesDead[3] && EnemiesAlive==4)
        {
            CheckIsEnemiesDead[3] = true;
            wavespawner.EnemiesAlive--;
        }

        if (wavespawner.EnemiesAlive > 0)
        {
            return;
        }
        else if (wavespawner.EnemiesAlive <= 0 && wavespawner.waveIndex < 3)
        {
            wavespawner.SpawnWave();
            EnemiesAlive = wavespawner.EnemiesAlive;
            for (int i=0;i<=3;i++)
            {
                CheckIsEnemiesDead[i] = false;
            }
        }
        else if (wavespawner.EnemiesAlive <= 0 && wavespawner.waveIndex >= 3)
        {
            WinLevel();
        }
    }
    void CheckIfEHeroesDead()
    {
        if(wavespawner.hero1.HeroState == HeroStates.Dead && wavespawner.hero2.HeroState == HeroStates.Dead)
        {
            LoseLevel();
        }
    }

    public void Skill1()
    {
        if(turns == BattleState.Hero1)
        {
            hero1.Set_Skill1();
        }
        else if(turns == BattleState.Hero2)
        {
            hero2.Set_Skill1();
        }
    }
    public void Skill2()
    {
        if (turns == BattleState.Hero1)
        {
            hero1.Set_Skill2();
        }
        else if (turns == BattleState.Hero2)
        {
            hero2.Set_Skill2();
        }
    }
    public void Skill3()
    {
        if (turns == BattleState.Hero1)
        {
            hero1.Set_Skill3();
        }
        else if (turns == BattleState.Hero2)
        {
            hero2.Set_Skill3();
        }
    }
    public void Skill4()
    {
        if (turns == BattleState.Hero1)
        {
            hero1.Set_Skill4();
        }
        else if (turns == BattleState.Hero2)
        {
            hero2.Set_Skill4();
        }
    }
}
