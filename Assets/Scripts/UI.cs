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

    private Player hero1;
    private Player hero2;
    public Monsterscript enemy1;
    public Monsterscript enemy2;
    public Monsterscript enemy3;
    public Monsterscript enemy4;

    public Player hero;
    public Monsterscript enemy;
    public screen_transition st;

    private string skillchoose;

    void Start ()
    {
        StartCoroutine(StartingHUD());
        InvokeRepeating("update", 3.0f, 1.0f);
    }
    void Update()
    {
        HPCheck();
    }
    IEnumerator StartingHUD()
    {
        yield return new WaitForSeconds(0.2f);
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

        if (wavespawner.EnemiesAlive >= 2)
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
    }
    void WinLevel()
    {
        completeLevelUI.SetActive(true);
    }
    void HPCheck()
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
    IEnumerator BattleStart()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(Hero1());
    }

    IEnumerator Hero1()
    {
        CheckIfEnemiesDead();
        CheckIfEHeroesDead();
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
        CheckIfEnemiesDead();
        CheckIfEHeroesDead();
    }
    IEnumerator Hero2()
    {
        CheckIfEnemiesDead();
        CheckIfEHeroesDead();
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
        CheckIfEnemiesDead();
        CheckIfEHeroesDead();
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
    IEnumerator Enemy1()
    {
        CheckIfEnemiesDead();
        CheckIfEHeroesDead();
        turns = BattleState.Enemy1;
        yield return new WaitForSeconds(2f);
        skill1.gameObject.SetActive(false);
        skill2.gameObject.SetActive(false);
        skill3.gameObject.SetActive(false);
        skill4.gameObject.SetActive(false);
        hero2Btn.enabled = false;
        Hero2Name.enabled = false;
        if (!enemy1.IsDead)
        {
            enemy = enemy1;
            EnemyAttack();
            enemy1.Set_Attack();
            SkillScreenEnemy();
        }
        yield return new WaitForSeconds(2f);
        CheckIfEnemiesDead();
        CheckIfEHeroesDead();
        if (!wavespawner.IsBoss)
        StartCoroutine(Enemy2());
        else
            StartCoroutine(Hero1());
    }
    IEnumerator Enemy2()
    {
        CheckIfEnemiesDead();
        CheckIfEHeroesDead();
        turns = BattleState.Enemy2;
        yield return new WaitForSeconds(2f);
        if (!enemy2.IsDead)
        {
            enemy = enemy2;
            EnemyAttack();
            enemy2.Set_Attack();
            SkillScreenEnemy();
        }
        yield return new WaitForSeconds(2f);
        CheckIfEnemiesDead();
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
        CheckIfEnemiesDead();
        CheckIfEHeroesDead();
        turns = BattleState.Enemy3;
        yield return new WaitForSeconds(2f);
        if (!enemy3.IsDead)
        {
            enemy = enemy3;
            EnemyAttack();
            enemy3.Set_Attack();
            SkillScreenEnemy();
        }
        yield return new WaitForSeconds(2f);
        CheckIfEnemiesDead();
        CheckIfEHeroesDead();
        if (wavespawner.EnemiesAlive == 4)
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
        CheckIfEnemiesDead();
        CheckIfEHeroesDead();
        turns = BattleState.Enemy4;
        yield return new WaitForSeconds(2f);
        if (!enemy4.IsDead)
        {
            enemy = enemy4;
            EnemyAttack();
            enemy4.Set_Attack();
            SkillScreenEnemy();
        }
        yield return new WaitForSeconds(2f);
        CheckIfEnemiesDead();
        CheckIfEHeroesDead();

        StartCoroutine(Hero1());
    }
    void CheckIfEnemiesDead()
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
            wavespawner.SpawnWave();
                EnemiesAlive = wavespawner.EnemiesAlive;
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
    void CheckIfEHeroesDead()
    {
        if(hero1.IsDead && hero2.IsDead)
        {
            LoseLevel();
        }
    }

    private void Skill1()
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
    private void Skill2()
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
    private void Skill3()
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
    private void Skill4()
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
    public void ChoosingEnemy(Button btn)
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
    public void ChoosingSkill(Button btn)
    {
        if (btn.name == "Skill1")
        {
            skillchoose = btn.name;
            if (hero.HeroName == "Wizard" && !CheckIsEnemiesDead[0])
            {
                Skill1();
                SkillScreenHero();
                FromHero();
            }
        }
        else if (btn.name == "Skill2" && !CheckIsEnemiesDead[0] && !CheckIsEnemiesDead[1])
        {
            skillchoose = btn.name;
            if (hero.HeroName == "GirlKnight" || hero.HeroName == "Wizard")
            {
                Skill2();
                SkillScreenHero();
                FromHero();
            }
        }
        else if (btn.name == "Skill3" && !CheckIsEnemiesDead[2] && !CheckIsEnemiesDead[1])
        {
            skillchoose = btn.name;
            if ( hero.HeroName == "Wizard" && EnemiesAlive>=3)
            {
                Skill3();
                SkillScreenHero();
                FromHero();
            }
        }
        else if (btn.name == "Skill4" && !CheckIsEnemiesDead[3] && !CheckIsEnemiesDead[1] && !CheckIsEnemiesDead[2])
        {
            skillchoose = btn.name;
            if (hero.HeroName == "Brother" || (hero.HeroName == "Wizard" && EnemiesAlive >= 4))
            {
                Skill4();
                SkillScreenHero();
                FromHero();
            }
        }

        if(wavespawner.IsBoss)
        {
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
                FromHero();
            }
        }
    }
    private void EnemyAttack()
    {
            if (UnityEngine.Random.Range(1, 10) % 2 != 0)
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
    private void SkillScreenHero ()
    {
        st.Blood(hero.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length * 0.65f);
    }
    private void SkillScreenEnemy()
    {
        st.Blood(enemy.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length * 0.65f);
    }
}


