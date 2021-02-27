using UnityEngine;
using UnityEngine.UI;

public class Monsterscript : MonoBehaviour
{
    private Animator m_animator;
    private Rigidbody2D m_body2d;
    private Sensor m_groundSensor;
    private float m_delayToIdle = 0.0f;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor>();
        Idle();
    }

    void Attack ()
    {
            m_animator.SetTrigger("Attack");
        }
    void Death ()
    {
        m_animator.SetTrigger("Death");
    }
    void Idle ()
    {
            // Prevents flickering transitions to idle
            m_delayToIdle -= Time.deltaTime;
            if (m_delayToIdle < 0)
            { }
        }
    void Hurt()
    {
            m_animator.SetTrigger("Hurt");
    }
}
