// Script of all UI and combat game
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
    public bool[] CheckIsEnemiesDead = {false,false,false,false};
    static int EnemiesAlive;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    [SerializeField]
    public AudioClip[] music = new AudioClip[8];

    int[] musicnumbers = new int[8];
    int musicnumber = 1;
    float musiclength = 0.0f;

    public GameObject panel;

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

    public Player hero1;
    public Player hero2;
    public Monsterscript enemy1;
    public Monsterscript enemy2;
    public Monsterscript enemy3;
    public Monsterscript enemy4;

    public Player hero;
    public Monsterscript enemy;
    public screen_transition st;

    private string skillchoose;

    void Start()//starting levels configuration
    {
        Time.timeScale = 1;
        StartCoroutine(StartingHUD());
        InvokeRepeating("updating", 3.0f, 1.0f);
        InvokeRepeating("Music", 2.0f, 1.0f);
        for (int i = 0; i < 8; i++)//setup random array of music for level
        {
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7 };
            musicnumbers[i] = UnityEngine.Random.Range(0, 8);
            if (musicnumbers[i] == numbers[musicnumbers[i]])
            {
                numbers[musicnumbers[i]] = -1;
            }
            else
            {
                i--;
            }
        }
        gameObject.GetComponent<AudioSource>().clip = music[musicnumbers[0]];
        gameObject.GetComponent<AudioSource>().PlayDelayed(1);
        musiclength = gameObject.GetComponent<AudioSource>().clip.length + 1.0f;
    }
    void Music()//continueing of musics tracks 
    {
        musiclength -= 1.0f;
        if (musiclength < 0)
        {
            gameObject.GetComponent<AudioSource>().clip = music[musicnumbers[musicnumber]];
            gameObject.GetComponent<AudioSource>().Play();
            musiclength = gameObject.GetComponent<AudioSource>().clip.length;
            musicnumber++;
            if (musicnumber == 7)
            {
                musicnumber = 0;
            }
        }
    }
    void updating()//updating of info in UI for player
    {
        HPCheck();
        CheckIfEHeroesDead();
        CheckIfEnemiesDead();
    }
    IEnumerator StartingHUD()//starting levels configuration, heroes pictures, skill pictures, etc in UI
    {
        yield return new WaitForSeconds(0.3f);
        panel.SetActive(false);
        hero1Btn.image.sprite = wavespawner.hero1.HeroImage;
        hero2Btn.image.sprite = wavespawner.hero2.HeroImage;

        Hero1Name.text = wavespawner.hero1.HeroName;
        Hero2Name.text = wavespawner.hero2.HeroName;

        hero1Btn.enabled = false;
        Hero1Name.enabled = false;
        hero2Btn.enabled = false;
        Hero2Name.enabled = false;
        enemy2Slider.gameObject.SetActive(false);
        enemy2HPText.gameObject.SetActive(false);
        enemy3Slider.gameObject.SetActive(false);
        enemy3HPText.gameObject.SetActive(false);
        enemy4Slider.gameObject.SetActive(false);
        enemy4HPText.gameObject.SetActive(false);

        hero1 = GameObject.Find(wavespawner.hero1.HeroName + "(Clone)").GetComponent<Player>();
        hero2 = GameObject.Find(wavespawner.hero2.HeroName + "(Clone)").GetComponent<Player>();
        enemy1 = GameObject.Find(wavespawner.enemy1.EnemyName + "(Clone)").GetComponent<Monsterscript>();

        hero1.health = hero1.MaxHealth;
        hero2.health = hero2.MaxHealth;
        if (wavespawner.IsBoss)
        {
            enemy = enemy1;
        }

        if (wavespawner.EnemiesAlive >= 2)//cheks for safety
        {
            enemy2 = GameObject.Find(wavespawner.enemy2.EnemyName + "(Clone)").GetComponent<Monsterscript>();
            enemy2Slider.gameObject.SetActive(true);
            enemy2HPText.gameObject.SetActive(true);
        }
        if(wavespawner.EnemiesAlive>=3)
        {
            enemy3 = GameObject.Find(wavespawner.enemy3.EnemyName + "(Clone)").GetComponent<Monsterscript>();
            enemy3Slider.gameObject.SetActive(true);
            enemy3HPText.gameObject.SetActive(true);
        }
        if (wavespawner.EnemiesAlive >= 4)
        {
            enemy4 = GameObject.Find(wavespawner.enemy4.EnemyName + "(Clone)").GetComponent<Monsterscript>();
            enemy4Slider.gameObject.SetActive(true);
            enemy4HPText.gameObject.SetActive(true);
        }
         skill1.image.sprite = wavespawner.hero1.Skill1Image;
         skill2.image.sprite = wavespawner.hero1.Skill2Image;
         skill3.image.sprite = wavespawner.hero1.Skill3Image;
         skill4.image.sprite = wavespawner.hero1.Skill4Image;

        EnemiesAlive = wavespawner.EnemiesAlive;

        turns = BattleState.Waiting;
        StartCoroutine(BattleStart());
    }
    void LoseLevel()
    {
        gameOverUI.SetActive(true);
        gameObject.GetComponent<AudioSource>().Stop();
    }
    void WinLevel()
    {
        completeLevelUI.SetActive(true);
        gameObject.GetComponent<AudioSource>().Stop();
    }
    void HPCheck()//Updating of heroes and enemies HP in UI
    {
        hero1Slider.value = Convert.ToSingle(hero1.health) / Convert.ToSingle(hero1.MaxHealth);
        hero2Slider.value = Convert.ToSingle(hero2.health) / Convert.ToSingle(hero2.MaxHealth);
        hero1HPText.text = Convert.ToString(hero1.health) + " / " + Convert.ToString(hero1.MaxHealth);
        hero2HPText.text = Convert.ToString(hero2.health) + " / " + Convert.ToString(hero2.MaxHealth);

        enemy1Slider.value = Convert.ToSingle(enemy1.health) / Convert.ToSingle(enemy1.MaxHealth);
        enemy1HPText.text = Convert.ToString(enemy1.health) + " / " + Convert.ToString(enemy1.MaxHealth);

        if (wavespawner.EnemiesAlive >= 2)
        {
            enemy2Slider.value = Convert.ToSingle(enemy2.health) / Convert.ToSingle(enemy2.MaxHealth);
            enemy2HPText.text = Convert.ToString(enemy2.health) + " / " + Convert.ToString(enemy2.MaxHealth);
        }
        if (wavespawner.EnemiesAlive >= 3)
        {
            enemy3Slider.value = Convert.ToSingle(enemy3.health) / Convert.ToSingle(enemy3.MaxHealth);
            enemy3HPText.text = Convert.ToString(enemy3.health) + " / " + Convert.ToString(enemy3.MaxHealth);
        }
        if (wavespawner.EnemiesAlive >= 4)
        {
            enemy4Slider.value = Convert.ToSingle(enemy4.health) / Convert.ToSingle(enemy4.MaxHealth);
            enemy4HPText.text = Convert.ToString(enemy4.health) + " / " + Convert.ToString(enemy4.MaxHealth);
        }
    }
    IEnumerator BattleStart()//Start of first turn by 1 hero
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(Hero1());
    }

    IEnumerator Hero1()//preparing for first hero turn, updating ui
    {
        turns = BattleState.Hero1;
        yield return new WaitForSeconds(3f);
        if (hero1.IsDead)
        {
            hero1.Set_Recovery();
            FromHero();
        }
        else 
        {
            skill1.gameObject.SetActive(true);
            skill2.gameObject.SetActive(true);
            skill3.gameObject.SetActive(true);
            skill4.gameObject.SetActive(true);
            hero1Btn.enabled = true;
            Hero1Name.enabled = true;
            hero = hero1;
            skill1.image.sprite = wavespawner.hero1.Skill1Image;
            skill2.image.sprite = wavespawner.hero1.Skill2Image;
            skill3.image.sprite = wavespawner.hero1.Skill3Image;
            skill4.image.sprite = wavespawner.hero1.Skill4Image;
        }
        yield return new WaitForSeconds(3f);
        panel.SetActive(false);
    }
    IEnumerator Hero2()//preparing for second hero turn, updating ui
    {
        turns = BattleState.Hero2;
        yield return new WaitForSeconds(3f);
        if (hero2.IsDead)
        {
            hero2.Set_Recovery();
            FromHero();
        }
        else
        {
            skill1.gameObject.SetActive(true);
            skill2.gameObject.SetActive(true);
            skill3.gameObject.SetActive(true);
            skill4.gameObject.SetActive(true);
            hero1Btn.enabled = false;
            Hero1Name.enabled = false;
            hero2Btn.enabled = true;
            Hero2Name.enabled = true;
            hero = hero2;
            skill1.image.sprite = wavespawner.hero2.Skill1Image;
            skill2.image.sprite = wavespawner.hero2.Skill2Image;
            skill3.image.sprite = wavespawner.hero2.Skill3Image;
            skill4.image.sprite = wavespawner.hero2.Skill4Image;
        }
        yield return new WaitForSeconds(3f);
        panel.SetActive(false);
    }
    public void FromHero()
    {
        if (turns == BattleState.Hero1)
        {
            StartCoroutine(Hero2());
        }
        else if (turns == BattleState.Hero2)
        {
            StartCoroutine(Enemy1());
        }
    }
    IEnumerator Enemy1()//preparing for first enemy turn, updating ui
    {
        panel.SetActive(false);
        turns = BattleState.Enemy1;
        yield return new WaitForSeconds(3f);
        skill1.gameObject.SetActive(false);
        skill2.gameObject.SetActive(false);
        skill3.gameObject.SetActive(false);
        skill4.gameObject.SetActive(false);
        hero2Btn.enabled = false;
        Hero2Name.enabled = false;
        if (!enemy1.IsDead && !CheckIfEHeroesDead())
        {
            enemy = enemy1;
            EnemyAttack();
            enemy1.Set_Attack();
            SkillScreenEnemy();
        }
        yield return new WaitForSeconds(3f);
        if (!CheckIfEHeroesDead())
        {
            if (!wavespawner.IsBoss)
                StartCoroutine(Enemy2());
            else
                StartCoroutine(Hero1());
        }
    }
    IEnumerator Enemy2()//preparing for second enemy turn, updating ui
    {
        panel.SetActive(false);
        turns = BattleState.Enemy2;
        yield return new WaitForSeconds(3f);
        if (!enemy2.IsDead && !CheckIfEHeroesDead())
        {
            enemy = enemy2;
            EnemyAttack();
            enemy2.Set_Attack();
            SkillScreenEnemy();
        }
        yield return new WaitForSeconds(3f);
        if (!CheckIfEHeroesDead())
        {
            if (EnemiesAlive >= 3)
            {
                StartCoroutine(Enemy3());
            }
            else
            {
                StartCoroutine(Hero1());
            }
        }
    }
    IEnumerator Enemy3()//preparing for third enemy if it is turn, updating ui
    {
        panel.SetActive(false);
        turns = BattleState.Enemy3;
        yield return new WaitForSeconds(3f);
        if (!enemy3.IsDead && !CheckIfEHeroesDead())
        {
            enemy = enemy3;
            EnemyAttack();
            enemy3.Set_Attack();
            SkillScreenEnemy();
        }
        yield return new WaitForSeconds(3f);
        if (!CheckIfEHeroesDead())
        {
            if (EnemiesAlive == 4)
            {
                StartCoroutine(Enemy4());
            }
            else
            {
                StartCoroutine(Hero1());
            }
        }
    }
    IEnumerator Enemy4()//preparing for fourth enemy if it is turn, updating ui
    {
        panel.SetActive(false);
        turns = BattleState.Enemy4;
        yield return new WaitForSeconds(3f);
        if (!enemy4.IsDead && !CheckIfEHeroesDead())
        {
            enemy = enemy4;
            EnemyAttack();
            enemy4.Set_Attack();
            SkillScreenEnemy();
        }
        yield return new WaitForSeconds(3f);
        if (!CheckIfEHeroesDead())
        {
            StartCoroutine(Hero1());
        }
    }
    void CheckIfEnemiesDead()//chek if enemies dead, spawn enemy or win level if it true
    {
       if(!wavespawner.IsBoss)
       {
        if (enemy1.IsDead && !CheckIsEnemiesDead[0])
        {
            CheckIsEnemiesDead[0] = true;
            wavespawner.EnemiesAlive--;
                enemy1Slider.gameObject.SetActive(false);
                enemy1HPText.gameObject.SetActive(false);
        }
        if (enemy2.IsDead && !CheckIsEnemiesDead[1])
        {
            CheckIsEnemiesDead[1] = true;
            wavespawner.EnemiesAlive--;
                enemy2Slider.gameObject.SetActive(false);
                enemy2HPText.gameObject.SetActive(false);
        }
        if (EnemiesAlive >= 3)
        {
            if (enemy3.IsDead && !CheckIsEnemiesDead[2])
            {
                CheckIsEnemiesDead[2] = true;
                wavespawner.EnemiesAlive--;
                    enemy3Slider.gameObject.SetActive(false);
                    enemy3HPText.gameObject.SetActive(false);
            }
        }
        if (EnemiesAlive == 4)
        {
            if (enemy4.IsDead && !CheckIsEnemiesDead[3])
            {
                CheckIsEnemiesDead[3] = true;
                wavespawner.EnemiesAlive--;
                enemy4Slider.gameObject.SetActive(false);
                enemy4HPText.gameObject.SetActive(false);
            }
        }

        if (wavespawner.EnemiesAlive > 0)
        {
            return;
        }
        else if (wavespawner.EnemiesAlive <= 0 && wavespawner.waveIndex < 3)
        {
            StartCoroutine(SpawnWave());
            EnemiesAlive = wavespawner.EnemiesAlive;
            StartCoroutine(StartingHUD());
            for (int i = 0; i <= 3; i++)
            {
                CheckIsEnemiesDead[i] = false;
            }
                StartCoroutine(StartingHUD());
        }
        else if (wavespawner.EnemiesAlive <= 0 && wavespawner.waveIndex >= 3)
        {
            WinLevel();
        }
       }
        else if (enemy1.IsDead && wavespawner.IsBoss)
        {
            WinLevel();
        }
    }
    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(3f);
        wavespawner.SpawnWave();
    }
    bool CheckIfEHeroesDead()// chek if both heroes dead, if it true lose level
    {
        if(hero1.IsDead && hero2.IsDead)
        {
            panel.SetActive(false);
            LoseLevel();
            return true;
        }
        return false;
    }

    private void Skill1()//if player chossing 1 skill, activate panel for enemy choosing
    {
        if(turns == BattleState.Hero1)
        {
            hero1.Set_Skill1();
        }
        else if(turns == BattleState.Hero2)
        {
            hero2.Set_Skill1();
        }
        panel.SetActive(true);
    }
    private void Skill2()//if player chossing 2 skill, activate panel for enemy choosing
    {
        if (turns == BattleState.Hero1)
        {
            hero1.Set_Skill2();
        }
        else if (turns == BattleState.Hero2)
        {
            hero2.Set_Skill2();
        }
        panel.SetActive(true);
    }
    private void Skill3()//if player chossing 3 skill, activate panel for enemy choosing
    {
        if (turns == BattleState.Hero1)
        {
            hero1.Set_Skill3();
        }
        else if (turns == BattleState.Hero2)
        {
            hero2.Set_Skill3();
        }
        panel.SetActive(true);
    }
    private void Skill4()//if player chossing 4 skill, activate panel for enemy choosing
    {
        if (turns == BattleState.Hero1)
        {
                hero1.Set_Skill4();
        }
        else if (turns == BattleState.Hero2)
        {
            hero2.Set_Skill4();
        }
        panel.SetActive(true);
    }
    public void ChoosingEnemy(Button btn)//choosing enemy of a hero skill
    {
            if (btn.name == "1")
            {
                enemy = enemy1;
            }
            else if (btn.name == "2")
            {
                enemy = enemy2;
            }
            else if (btn.name == "3")
            {
                enemy = enemy3;
            }
            else if (btn.name == "4")
            {
                enemy = enemy4;
            }
            if (!enemy.IsDead)
            {
                if (skillchoose == "Skill1")
                {
                    Skill1();
                    SkillScreenHero();
                }
                else if (skillchoose == "Skill2")
                {
                    Skill2();
                    SkillScreenHero();
                }
                else if (skillchoose == "Skill3")
                {
                    Skill3();
                    SkillScreenHero();
                }
                else if (skillchoose == "Skill4")
                {
                    Skill4();
                    SkillScreenHero();
                }
            } 
    }
    public void ChoosingSkill(Button btn)//using choosed skill
    {
        if (btn.name == "Skill1")
        {
            skillchoose = btn.name;
            if (hero.HeroName == "Wizard" && !CheckIsEnemiesDead[0])
            {
                panel.SetActive(false);
                Skill1();
                panel.SetActive(false);
                SkillScreenHero();
                FromHero();
            }
        }
        else if (btn.name == "Skill2" && !CheckIsEnemiesDead[0] && !CheckIsEnemiesDead[1])
        {
            skillchoose = btn.name;
            if (hero.HeroName == "Wizard")
            {
                panel.SetActive(false);
                Skill2();
                panel.SetActive(false);
                SkillScreenHero();
                FromHero();
            }
        }
        else if (btn.name == "Skill3" && !CheckIsEnemiesDead[2] && !CheckIsEnemiesDead[1])
        {
            skillchoose = btn.name;
            if ((hero.HeroName == "GirlKnight" || hero.HeroName == "Wizard") && EnemiesAlive>=3)
            {
                panel.SetActive(false);
                Skill3();
                panel.SetActive(false);
                SkillScreenHero();
                FromHero();
            }
        }
        else if (btn.name == "Skill4" && !CheckIsEnemiesDead[3] && !CheckIsEnemiesDead[1] && !CheckIsEnemiesDead[2])
        {
            skillchoose = btn.name;
            if ((hero.HeroName == "Brother" || hero.HeroName == "Wizard") && EnemiesAlive >= 4)
            {
                panel.SetActive(false);
                Skill4();
                panel.SetActive(false);
                SkillScreenHero();
                FromHero();
            }
        }

        if(wavespawner.IsBoss)
        {
            panel.SetActive(false);
            if (!enemy.IsDead)
            {
                if (skillchoose == "Skill1")
                {
                    Skill1();
                    panel.SetActive(false);
                    SkillScreenHero();
                }
                else if (skillchoose == "Skill2")
                {
                    Skill2();
                    panel.SetActive(false);
                    SkillScreenHero();
                }
                else if (skillchoose == "Skill3")
                {
                    Skill3();
                    panel.SetActive(false);
                    SkillScreenHero();
                }
                else if (skillchoose == "Skill4")
                {
                    Skill4();
                    panel.SetActive(false);
                    SkillScreenHero();
                }
                FromHero();
            }
        }
    }
    private void EnemyAttack() // simple recursive function choosing which hero will be attacked by enemy 
    {
            if ((UnityEngine.Random.Range(1, 11) % 2) != 0)
            {
                hero = hero1;
            if (hero.IsDead)
            {
                EnemyAttack();
            }
            }
            else
            {
                hero = hero2;
            if (hero.IsDead)
            {
                EnemyAttack();
            }
            }
    }
    private void SkillScreenHero ()//Enabling screen of taking damage by hero
    {
        st.Blood(hero.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length * 0.65f);
    }
    private void SkillScreenEnemy()//Enabling screen of taking damage by enemy
    {
        st.Blood(enemy.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length * 0.65f);
    }
}


