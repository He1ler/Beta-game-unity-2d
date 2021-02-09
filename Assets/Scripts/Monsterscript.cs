using UnityEngine;
using UnityEngine.UI;

public class Monsterscript : MonoBehaviour
{
    private Animator m_animator;
    private Rigidbody2D m_body2d;
    private Sensor m_groundSensor;
    private float m_delayToIdle = 0.0f;

    public float startHealth = 100;
    public bool IsDeadEnemie = false;
    private float health;
    [Header("Unity Stuff")]
    public Image healthBar;
    // Use this for initialization
    void Start()
    {
        health = startHealth;
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
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !IsDeadEnemie)
        {
            Die();
        }
    }
    void Die()
    {
        IsDeadEnemie = true;

        //GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
       // Destroy(effect, 5f);

       // WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
}
