using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterscript : MonoBehaviour
{
    [SerializeField] float m_speed = 4.0f;
    private Animator m_animator;
    private Rigidbody2D m_body2d;
    private Sensor m_groundSensor;
    private float m_delayToIdle = 0.0f;

    // Use this for initialization
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor>();
    }

    // Update is called once per frame
    void Update()
    {
        //Death
        if (Input.GetKeyDown("e") && !Pausemenu.GameisPaused)
        {
            m_animator.SetTrigger("Death");
        }

        //Hurt
        else if (Input.GetKeyDown("q") && !Pausemenu.GameisPaused)
        { m_animator.SetTrigger("Hurt"); }

        //Attack
        else if (Input.GetMouseButtonDown(0) && !Pausemenu.GameisPaused)
        {
            m_animator.SetTrigger("Attack");
        }

        //Idle
        else
        {
            // Prevents flickering transitions to idle
            m_delayToIdle -= Time.deltaTime;
            if (m_delayToIdle < 0)
            { m_animator.SetInteger("AnimState", 0); }
        }
    }
}
