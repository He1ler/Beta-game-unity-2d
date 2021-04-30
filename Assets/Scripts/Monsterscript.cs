using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
public class Monsterscript : MonoBehaviour
{
    private Animator m_animator;
    private float m_delayToIdle = 0.0f;
    UI ui;
    public string EnemyName;
    public int health;
    public int AttackDamage;
    public int MaxHealth;
    public bool IsDead = false;
    public AudioClip Attack;
    public AudioClip Death;
    private EnemyData ed;
    public AudioSource AS;
    void Start()
    {
        Time.timeScale = 1;
        ed = DataTransition.EnemyFromFile(EnemyName);
        health = ed.health;
        MaxHealth = ed.health;
        AttackDamage = ed.AttackDamage;
        ui = GameObject.Find("UI").GetComponent<UI>();
        m_animator = GameObject.Find(EnemyName + "(Clone)").GetComponent<Animator>();
        AS = GameObject.Find(EnemyName + "(Clone)").GetComponent<AudioSource>();
    }
    public void Set_Death()
    {
        if (!Pausemenu.GameisPaused)
        {
            m_animator.SetTrigger("Death");
            AS.clip = Death;
            AS.Play();
            IsDead = true;
            if (EnemyName == "burning-ghoul")
            {
                burningghoul();
                Destroy(this.gameObject, (GameObject.Find(EnemyName + "(Clone)").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length));
            }
            else
            {
                Destroy(this.gameObject, (GameObject.Find(EnemyName + "(Clone)").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 1f));
            }         
        }
    }
    public void Set_Hurt(int hp)
    {
        StartCoroutine(Set_HurtI(hp, GameObject.Find(ui.hero.HeroName + "(Clone)").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length * 0.7f));
    }

    public IEnumerator Set_HurtI(int hp, float f)
    {
        yield return new WaitForSeconds(f);
        if (!Pausemenu.GameisPaused && (!IsDead))
        {
            m_animator.SetTrigger("Hurt");
            health -= hp;
            if(health<=0)
            {
                health = 0;
                Set_Death();
            }
        }
    }
    public void Set_Idle()
    {
        if (!Pausemenu.GameisPaused && (!IsDead))
        {
            // Prevents flickering transitions to idle
            m_delayToIdle -= Time.deltaTime;
            if (m_delayToIdle < 0)
            { }
        }
    }
    public void Set_Attack()
    {
        if (!Pausemenu.GameisPaused &&(!ui.hero.IsDead)&& (!IsDead))
        {
            m_animator.SetTrigger("Attack");
            AS.clip = Attack;
            AS.Play();
            if (EnemyName == "burning-ghoul")
            {
                burningghoul();
            }
            else
            {
                ui.hero.Set_Hurt(AttackDamage);
            }
        }
    }
    void burningghoul ()
    {
        if(IsDead)
        {
            if (!ui.hero.IsDead)
            {
                ui.hero.Set_Hurt(AttackDamage);
            }
            if (!ui.enemy1.IsDead && ui.enemy1.EnemyName != "burning-ghoul")
            {
                ui.enemy1.Set_Hurt(AttackDamage);
            }
            if (!ui.enemy2.IsDead && ui.enemy2.EnemyName != "burning-ghoul")
            {
                ui.enemy2.Set_Hurt(AttackDamage);
            }
            if(ui.wavespawner.EnemiesAlive>=3)
            {
                if (!ui.enemy3.IsDead && ui.enemy3.EnemyName != "burning-ghoul")
                {
                    ui.enemy3.Set_Hurt(AttackDamage);
                }
            }
            if (ui.wavespawner.EnemiesAlive >= 4)
            {
                if (!ui.enemy4.IsDead && ui.enemy4.EnemyName != "burning-ghoul")
                {
                    ui.enemy4.Set_Hurt(AttackDamage);
                }
            }
        }
        else
        {
            if (!ui.hero1.IsDead)
            {
                ui.hero1.Set_Hurt(AttackDamage);
            }
            if (!ui.hero2.IsDead)
            {
                ui.hero2.Set_Hurt(AttackDamage);
            }
        }
    }
}
