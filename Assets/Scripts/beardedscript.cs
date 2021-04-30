using UnityEngine;

public class beardedscript : MonoBehaviour
{
    [SerializeField] float m_speed = 4.0f;
    private Animator m_animator;
    private Sensor m_groundSensor;
    private bool m_grounded = false;
    public float m_time = 51f;
    private bool leftright = false;
    public Transform groundDetection;
    public Vector3 walkingChangeXY1 = new Vector3(38, 193, 0);
    public Vector3 walkingChangeXY2 = new Vector3(178, 193, 0);
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        m_animator = GetComponent<Animator>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor>();
    }

    // Update is called once per frame
    void Update()
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

        m_time -= 1;

        if (m_time <= 0 && m_grounded && !Pausemenu.GameisPaused)
        {
            if (leftright == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, walkingChangeXY2, m_speed * Time.deltaTime);
                m_animator.SetInteger("AnimState", 1);
                if (groundDetection.position == walkingChangeXY2)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                    leftright = !leftright;
                    m_time = 5001;
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, walkingChangeXY1, m_speed*Time.deltaTime);
                m_animator.SetInteger("AnimState", 1);
                if (groundDetection.position == walkingChangeXY1)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                    leftright = !leftright;
                    m_time = 5001;
                }
            }
        }
        //Idle
        else
        {
                m_animator.SetInteger("AnimState", 0);
        }
    }
}