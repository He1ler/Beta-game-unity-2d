using UnityEngine;

public class Player : MonoBehaviour {

   // [SerializeField] float m_speed = 4.0f;
    private Animator m_animator;
    //private Rigidbody2D m_body2d;
    //private Sensor m_groundSensor;
    //private bool m_grounded = false;
    private float m_delayToIdle = 0.0f;
    
    UI ui;

    public string HeroName;
    public int health;
    public int Skill1Damage;
    public int Skill2Damage;
    public int Skill3Damage;
    public int Skill4Damage;
    public int MaxHealth;

    public bool IsDead = false;

    private HeroData hd;
    void Start()
    {
        hd = DataTransition.HeroFromFile(HeroName);
        health = hd.health;
        Skill1Damage = hd.Skill1Damage;
        Skill2Damage = hd.Skill2Damage;
        Skill3Damage = hd.Skill3Damage;
        Skill4Damage = hd.Skill4Damage;
        MaxHealth = hd.health;
        ui = GameObject.Find("UI").GetComponent<UI>();
        m_animator = GameObject.Find(HeroName + "(Clone)").GetComponent<Animator>();
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
    void Update ()
    {
        if (IsDead)
        {
            health += (MaxHealth / 10);
            if(health >= MaxHealth)
            {
                health = MaxHealth;
                IsDead = false;
                Set_Recovery();
            }
        }
    }
    public void Set_Death()
    {
            m_animator.SetTrigger("Death");
            m_animator.SetInteger("death", 1);
            IsDead = true;
    }
    public void Set_Hurt(int hp)
    {
        if (!IsDead)
        {
            m_animator.SetTrigger("Hurt");
            health -= hp;
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
    public void Set_Recovery()
    {
        if (!IsDead)
        {
            m_animator.SetTrigger("Recovery");
            m_animator.SetInteger("death", 0);
        }
    }
    public void Set_Skill1()
    {
        if (!ui.enemy.IsDead && !IsDead)
        {
            m_animator.SetTrigger("Skill1");
            ui.enemy.Set_Hurt(Skill1Damage);
        }
    }
    public void Set_Skill2()
    {
        if (!ui.enemy.IsDead && !IsDead)
        {
            m_animator.SetTrigger("Skill2");
            ui.enemy.Set_Hurt(Skill2Damage);
        }
    }
    public void Set_Skill3()
    {
        if (!ui.enemy.IsDead && !IsDead)
        {
            m_animator.SetTrigger("Skill3");
            ui.enemy.Set_Hurt(Skill3Damage);
        }
    }
    public void Set_Skill4()
    {
        if (!ui.enemy.IsDead && !IsDead)
        {
            m_animator.SetTrigger("Skill4");
            ui.enemy.Set_Hurt(Skill4Damage);
        }
        }

    /*
        private Animator m_animator;
    [SerializeField] GameObject Explosion;
    [SerializeField] GameObject FireExplosion;
    [SerializeField] GameObject Fireball;
    [SerializeField] GameObject Fireblast;
    public bool Explosioni = false;
    public bool Fireballi = false;
    [SerializeField] Sensor SpellsensorEXP;
    [SerializeField] Sensor Spellsensor;
    void Start()
    {
        m_animator = GetComponent<Animator>();
        SpellsensorEXP = transform.Find("SpellsensorEXP").GetComponent<Sensor>();
        Spellsensor = transform.Find("Spellsensor").GetComponent<Sensor>();
    }
    void Update ()
    {
        Vector3 spawnPosition3;
        Vector2 spawnPosition2;
        if (Input.GetKeyDown("1"))
        {
            Fireballi = true;
            spawnPosition3 = Spellsensor.transform.position;
            if (Fireball != null)
            {
                // Set correct arrow spawn position
                GameObject dust = Instantiate(Fireball, spawnPosition3, gameObject.transform.localRotation) as GameObject;
                // Turn arrow in correct direction
                dust.transform.localScale = new Vector3(1, 1, 1);
            }
            m_animator.SetBool("Fireballi", Fireballi);
        }
        else if (Input.GetKeyDown("2"))
        {
            Fireballi = true;
            spawnPosition3 = Spellsensor.transform.position;
            if (Fireblast != null)
            {
                // Set correct arrow spawn position
                GameObject dust = Instantiate(Fireblast, spawnPosition3, gameObject.transform.localRotation) as GameObject;
                // Turn arrow in correct direction
                dust.transform.localScale = new Vector3(1, 1, 1);
            }
            m_animator.SetBool("Fireballi", Fireballi);
        }
        else if (Input.GetKeyDown("3"))
        {
            Explosioni = true;
            spawnPosition2 = SpellsensorEXP.transform.position;
            if (Explosion != null)
            {
                // Set correct arrow spawn position
                GameObject dust = Instantiate(Explosion, spawnPosition2, gameObject.transform.localRotation) as GameObject;
                // Turn arrow in correct direction
                dust.transform.localScale = new Vector2(1, 1);
                m_animator.SetBool("Explosioni", Explosioni);
            }
        }
        else if (Input.GetKeyDown("4"))
        {
            Explosioni = true;
            spawnPosition2 = SpellsensorEXP.transform.position;
            if (FireExplosion != null)
            {
                // Set correct arrow spawn position
                GameObject dust = Instantiate(FireExplosion, spawnPosition2, gameObject.transform.localRotation) as GameObject;
                // Turn arrow in correct direction
                dust.transform.localScale = new Vector2(1, 1);
            }
            m_animator.SetBool("Explosioni", Explosioni);
            m_animator.SetBool("Explosioni", Explosioni);
        }
    }
     */
}
