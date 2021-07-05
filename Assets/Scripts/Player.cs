//Script for Hero unit
using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour {

   // [SerializeField] float m_speed = 4.0f;
    private Animator m_animator;
    //private Rigidbody2D m_body2d;
    //private Sensor m_groundSensor;
    //private bool m_grounded = false;
    private float m_delayToIdle = 0.0f;
    
    UI ui;

    public Object FireBlast;
    public Object FireBall;
    public Object FireExplosion;
    public Object BlackExplosion;

    public string HeroName;
    public int health;
    public int Skill1Damage;
    public int Skill2Damage;
    public int Skill3Damage;
    public int Skill4Damage;
    public int MaxHealth;

    public bool IsDead = false;

    private HeroData hd;
    public AudioClip Attack1;
    public AudioClip Attack2;
    public AudioClip Attack3;
    public AudioClip Attack4;
    public AudioClip Death;
    public AudioSource AS;
    void Start()//loading characteristics of hero from data files
    {
        Time.timeScale = 1;
        hd = DataTransition.HeroFromFile(HeroName);
        health = hd.health;
        Skill1Damage = hd.Skill1Damage;
        Skill2Damage = hd.Skill2Damage;
        Skill3Damage = hd.Skill3Damage;
        Skill4Damage = hd.Skill4Damage;
        MaxHealth = hd.health;
        ui = GameObject.Find("UI").GetComponent<UI>();
        m_animator = GameObject.Find(HeroName + "(Clone)").GetComponent<Animator>();
        AS = GameObject.Find(HeroName + "(Clone)").GetComponent<AudioSource>();
        // m_body2d = GetComponent<Rigidbody2D>();
        // m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor>();
    }

    // Update is called once per frame
    /*void Update()
    {
        
         //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0 && (IsDeadHero == false))
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        else if (inputX < 0 && (IsDeadHero == false))
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        // Move
        if (IsDeadHero == false && m_grounded)
        {
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        }
        else if (IsDeadHero == true)
        {
            m_body2d.velocity = new Vector2(0, m_body2d.velocity.y);
        }
        //Attack
         else if (Input.GetMouseButtonDown(0) && (IsDeadHero == false) && m_grounded && !Pausemenu.GameisPaused)
         {
              m_animator.SetTrigger("Attack");
          }

         //Run
         else if (Mathf.Abs(inputX) > Mathf.Epsilon && (IsDeadHero == false) && m_grounded && !Pausemenu.GameisPaused)
         {
             // Reset timer
             m_delayToIdle = 0.05f;
             m_animator.SetInteger("AnimState", 1);
         }

        //Death
        if (!Pausemenu.GameisPaused && ui.hero.HeroState == HeroStates.Dead && health <= 0)
        {
            m_animator.SetTrigger("Death");
            m_animator.SetInteger("death", 1);
        }

        //Recovery
        else if (!Pausemenu.GameisPaused && ui.hero.HeroState == HeroStates.Recovery)
        {
            m_animator.SetTrigger("Recovery");
            m_animator.SetInteger("death", 0);
            ui.hero.HeroState = HeroStates.Waiting;
        }

        //Hurt
        else if (!Pausemenu.GameisPaused && ui.enemy.EnemyState == EnemyStates.Attack)
        {
            m_animator.SetTrigger("Hurt");
            ui.hero.HeroState = HeroStates.Waiting;
        }
        //Idle
        else if (ui.hero.HeroState == HeroStates.Skill1)
        {
            m_animator.SetTrigger("Skill1");
            ui.hero.HeroState = HeroStates.Waiting;
        }
        else if (ui.hero.HeroState == HeroStates.Skill2)
        {
            m_animator.SetTrigger("Skill2");
            ui.hero.HeroState = HeroStates.Waiting;
        }
        else if (ui.hero.HeroState == HeroStates.Skill3)
        {
            m_animator.SetTrigger("Skill3");
            ui.hero.HeroState = HeroStates.Waiting;
        }
        else if (ui.hero.HeroState == HeroStates.Skill4)
        {
            m_animator.SetTrigger("Skill4");
            ui.hero.HeroState = HeroStates.Waiting;
        }
        else
        {
            // Prevents flickering transitions to idle
            m_delayToIdle -= Time.deltaTime;
            if (m_delayToIdle < 0)
                m_animator.SetInteger("AnimState", 0);
        }
    }*/
    public void Set_Death()
    {
            m_animator.SetTrigger("Death");
            AS.clip = Death;
            AS.Play();
            m_animator.SetInteger("death", 1);
            IsDead = true;
    }
    public void Set_Hurt(int hp)
    {
        StartCoroutine(Set_HurtI(hp, GameObject.Find(ui.hero.HeroName + "(Clone)").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length *0.7f));
    }
    private IEnumerator Set_HurtI(int hp, float f)
    {
        yield return new WaitForSeconds(f);
        if (!IsDead)
        {
            m_animator.SetTrigger("Hurt");
            health -= hp;
           // DataTransition.HeroHPToFile(HeroName, hp);
            if (health <= 0)
            {
                health = 0;
                Set_Death();
            }
        }
    }
    public void Set_Idle()
    {
        if (!IsDead)
        {
            m_delayToIdle -= Time.deltaTime;
            if (m_delayToIdle < 0)
                m_animator.SetInteger("AnimState", 0);
        }
    }
    public void Set_Recovery()//recoverieng from death (heroes dont die but fall down and should recover their hurts few rounds) 
    {
            health += 2*(MaxHealth / 10);
            if (health >= MaxHealth)
            {
                health = MaxHealth;
                IsDead = false;
            }
        if (!IsDead)
        {
            m_animator.SetTrigger("Recovery");
            m_animator.SetInteger("death", 0);
        }
    }
    public void Set_Skill1()
    {
            if (HeroName == "Wizard" && !IsDead && !ui.CheckIsEnemiesDead[0])//as wizard's first skill have constant enemies it will be done automatically
        {
                Vector3 SpelPos;
                Vector3 EnemyPos;
                SpelPos  = GameObject.Find(ui.hero.HeroName + "(Clone)").transform.position;
                EnemyPos = GameObject.Find(ui.enemy1.EnemyName + "(Clone)").transform.position;
                SpelPos.x += 85;
                SpelPos.y += 44;
                EnemyPos.y += 44;
                EnemyPos.x -= 44;
                m_animator.SetTrigger("Skill1");
                GameObject Spel = Instantiate(FireBlast, SpelPos, Quaternion.identity) as GameObject;
                Spel.GetComponent<Projectile>().Starting(EnemyPos);
                ui.enemy1.Set_Hurt(Skill1Damage);          
            }
        else if (!ui.enemy.IsDead && !IsDead)//skill script for other heroes
        {
            m_animator.SetTrigger("Skill1");
            ui.enemy.Set_Hurt(Skill1Damage);
        }
        AS.clip = Attack1;
        AS.Play();
    }
    public void Set_Skill2()
    {
        if (!IsDead)
        {
            if (HeroName == "Wizard" && !ui.CheckIsEnemiesDead[0] && !ui.CheckIsEnemiesDead[1])//as wizard's first skill have constant enemies it will be done automatically
            {
                Vector3 SpelPos;
                Vector3 EnemyPos;
                SpelPos = GameObject.Find(ui.hero.HeroName + "(Clone)").transform.position;
                EnemyPos = GameObject.Find(ui.enemy2.EnemyName + "(Clone)").transform.position;
                SpelPos.x += 85;
                SpelPos.y += 44;
                EnemyPos.y += 44;
                EnemyPos.x -= 64;
                m_animator.SetTrigger("Skill2");
                GameObject Spel = Instantiate(FireBall, SpelPos, Quaternion.identity) as GameObject;
                Spel.GetComponent<Projectile>().Starting(EnemyPos);
                ui.enemy1.Set_Hurt(Skill2Damage);
                ui.enemy2.Set_Hurt(Skill2Damage);
            }
            else if (!ui.enemy.IsDead)//skill script for other heroes
            {
                m_animator.SetTrigger("Skill2");
                ui.enemy.Set_Hurt(Skill2Damage);
            }
            AS.clip = Attack2;
            AS.Play();
        }
    }
    public void Set_Skill3()
    {
        if (HeroName == "Wizard" && !IsDead && !ui.CheckIsEnemiesDead[2] && !ui.CheckIsEnemiesDead[1])//as wizard's first skill have constant enemies it will be done automatically
        {
            Vector3 EnemyPos;
            EnemyPos = GameObject.Find(ui.enemy2.EnemyName + "(Clone)").transform.position;
            EnemyPos.y += 44;
            EnemyPos.x += 44;
            m_animator.SetTrigger("Skill3");
            GameObject Spel = Instantiate(FireExplosion, EnemyPos, Quaternion.identity) as GameObject;
            Destroy(Spel.gameObject, Spel.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            ui.enemy2.Set_Hurt(Skill3Damage);
            ui.enemy3.Set_Hurt(Skill3Damage);
        }
        else if (HeroName == "GirlKnight")//as Girls's first skill have not it will be done automatically
        {
            m_animator.SetTrigger("Skill3");
            health += 50;
        }
        else if (!ui.enemy.IsDead && !IsDead)//skill script for other heroes
        {
            m_animator.SetTrigger("Skill3");
                ui.enemy.Set_Hurt(Skill3Damage);
        }
        AS.clip = Attack3;
        AS.Play();
    }
    public void Set_Skill4()
    {
            if (HeroName == "Wizard" && !IsDead && !ui.CheckIsEnemiesDead[2] && !ui.CheckIsEnemiesDead[3] && !ui.CheckIsEnemiesDead[1])//as wizard's first skill have constant enemies it will be done automatically
        {
                Vector3 EnemyPos;
                EnemyPos = GameObject.Find(ui.enemy3.EnemyName + "(Clone)").transform.position;
                EnemyPos.y += 44;
                EnemyPos.x += 164;
                m_animator.SetTrigger("Skill4");
                GameObject Spel = Instantiate(BlackExplosion, EnemyPos, Quaternion.identity) as GameObject;
                Spel.transform.Rotate(0f, 0f, -92f);
                Destroy(Spel.gameObject, Spel.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                ui.enemy2.Set_Hurt(Skill4Damage);
                ui.enemy3.Set_Hurt(Skill4Damage);
                ui.enemy4.Set_Hurt(Skill4Damage);
            }
        else if (HeroName == "Brother")//as brother's first skill have not it will be done automatically
        {
            m_animator.SetTrigger("Skill4");
            health = 100;
        }
        else if (!ui.enemy.IsDead && !IsDead)//skill script for other heroes
        {
            m_animator.SetTrigger("Skill4");
            ui.enemy.Set_Hurt(Skill4Damage);
        }
        AS.clip = Attack4;
        AS.Play();
    }
}
