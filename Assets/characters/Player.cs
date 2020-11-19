using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField] float      m_speed = 4.0f;
    //[SerializeField] GameObject m_slideDust;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor   m_groundSensor;
   // private Sensor   m_wallSensorR1;
    //private Sensor   m_wallSensorL1;
    private bool                m_grounded = false;
    private bool                m_death = false;
  //  private int                 m_facingDirection = 1;
    private float               m_delayToIdle = 0.0f;


    // Use this for initialization
    void Start ()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor>();
       // m_wallSensorR1 = transform.Find("WallSensor_R1").GetComponent<Sensor>();
        //m_wallSensorL1 = transform.Find("WallSensor_L1").GetComponent<Sensor>();
    }

    // Update is called once per frame
    void Update ()
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
        if (inputX > 0 && (m_death == false))
        {
            GetComponent<SpriteRenderer>().flipX = false;
          //  m_facingDirection = 1;
        }
            
        else if (inputX < 0 && (m_death == false))
        {
            GetComponent<SpriteRenderer>().flipX = true;
          //  m_facingDirection = -1;
        }

        // Move
        if (m_death == false && m_grounded)
        {
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        }
        else if (m_death == true)
        {
            m_body2d.velocity = new Vector2(0, m_body2d.velocity.y);
        }

        //Death
        if (Input.GetKeyDown("e") && (m_death == false) && !Pausemenu.GameisPaused)
        {
            m_animator.SetTrigger("Death");
            m_death = true;
            m_animator.SetInteger("death", 1);
        }

        //Recovery
        else if (Input.GetKeyDown("space") && (m_death == true) && !Pausemenu.GameisPaused)
        {
            m_animator.SetTrigger("Recovery");
            m_death = false;
            m_animator.SetInteger("death", 0);
        }

        //Hurt
        else if (Input.GetKeyDown("q")&&(m_death == false) && m_grounded && !Pausemenu.GameisPaused)
            m_animator.SetTrigger("Hurt");

        //Attack
        else if (Input.GetMouseButtonDown(0) && (m_death == false) && m_grounded && !Pausemenu.GameisPaused)
        {
            m_animator.SetTrigger("Attack");
        }

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon && (m_death == false) && m_grounded && !Pausemenu.GameisPaused)
        {
            // Reset timer
            m_delayToIdle = 0.05f;
           /* Vector3 spawnPosition;
            if (m_facingDirection == 1)
            {
                spawnPosition = m_wallSensorR1.transform.position;
            }
            else
            {
                spawnPosition = m_wallSensorL1.transform.position;
            }
            if (m_slideDust != null)
            {
                // Set correct arrow spawn position
                GameObject dust = Instantiate(m_slideDust, spawnPosition, gameObject.transform.localRotation) as GameObject;
                // Turn arrow in correct direction
                dust.transform.localScale = new Vector3(m_facingDirection, 1, 1);
            }*/
            m_animator.SetInteger("AnimState", 1);
        }

        //Idle
        else
        {
            // Prevents flickering transitions to idle
            m_delayToIdle -= Time.deltaTime;
            if (m_delayToIdle < 0)
                m_animator.SetInteger("AnimState", 0);
        }
    }
}
