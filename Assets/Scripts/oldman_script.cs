using UnityEngine;

public class oldman_script : MonoBehaviour
{
    [SerializeField] float m_speed = 4.0f;
    private Animator m_animator;
    private Sensor m_groundSensor;
    private bool m_grounded = false;
    public Transform groundDetection;
    public Vector3 walkingChangeXY1 = new Vector3(38, 193, 0);
    private bool target = false;
    // Use this for initialization
    void Start()
    {
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

        if (m_grounded && !Pausemenu.GameisPaused && !target)
        {
                transform.position = Vector2.MoveTowards(transform.position, walkingChangeXY1, m_speed * Time.deltaTime);
                m_animator.SetInteger("AnimState", 1);
                if (groundDetection.position == walkingChangeXY1)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                target = true;
                }
        }
        //Idle
        else
        {
                m_animator.SetInteger("AnimState", 0);
        }
    }
}
