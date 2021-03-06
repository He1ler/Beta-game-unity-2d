using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Player : MonoBehaviour {

   // [SerializeField] float m_speed = 4.0f;
    private Animator m_animator;
    //private Rigidbody2D m_body2d;
    //private Sensor m_groundSensor;
    //private bool m_grounded = false;
    private float m_delayToIdle = 0.0f;

    UI ui;
    void Start()
    {
        ui = GameObject.Find("UI").GetComponent<UI>();
        m_animator = GetComponent<Animator>();
       // m_body2d = GetComponent<Rigidbody2D>();
       // m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
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
        }*/

        //Death
        if (!Pausemenu.GameisPaused && ui.hero.HeroState == HeroStates.Dead && ui.hero.health <= 0)
        {
            m_animator.SetTrigger("Death");
            m_animator.SetInteger("death", 1);
        }

        //Recovery
        else if (!Pausemenu.GameisPaused && ui.hero.HeroState == HeroStates.Recovery)
        {
            m_animator.SetTrigger("Recovery");
            m_animator.SetInteger("death", 0);
        }

        //Hurt
        else if (!Pausemenu.GameisPaused && ui.enemy.EnemyState == EnemyStates.Attack)
        {
            m_animator.SetTrigger("Hurt");
        }
        //Attack
        //  else if (Input.GetMouseButtonDown(0) && (IsDeadHero == false) && m_grounded && !Pausemenu.GameisPaused)
        //  {
        //      m_animator.SetTrigger("Attack");
        //  }

        /* //Run
         else if (Mathf.Abs(inputX) > Mathf.Epsilon && (IsDeadHero == false) && m_grounded && !Pausemenu.GameisPaused)
         {
             // Reset timer
             m_delayToIdle = 0.05f;
             m_animator.SetInteger("AnimState", 1);
         }*/
        //Idle
        else if (ui.hero.HeroState == HeroStates.Skill1)
        {
            ui.enemy.TakeDamage(ui.hero.Skill1Damage);
            m_animator.SetTrigger("Skill1");
        }
        else if (ui.hero.HeroState == HeroStates.Skill2)
        {
            ui.enemy.TakeDamage(ui.hero.Skill2Damage);
            m_animator.SetTrigger("Skill2");
        }
        else if (ui.hero.HeroState == HeroStates.Skill3)
        {
            ui.enemy.TakeDamage(ui.hero.Skill3Damage);
            m_animator.SetTrigger("Skill3");
        }
        else if (ui.hero.HeroState == HeroStates.Skill4)
        {
            ui.enemy.TakeDamage(ui.hero.Skill4Damage);
            m_animator.SetTrigger("Skill4");
        }
        else
        {
            // Prevents flickering transitions to idle
            m_delayToIdle -= Time.deltaTime;
            if (m_delayToIdle < 0)
                m_animator.SetInteger("AnimState", 0);
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
