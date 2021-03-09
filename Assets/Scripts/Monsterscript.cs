using UnityEngine;

public class Monsterscript : MonoBehaviour
{
    private Animator m_animator;
    private float m_delayToIdle = 0.0f;
    UI ui;
    public string EnemyName;
    public int health;
    public int AttackDamage;

    private EnemyData ed;
    void Start()
    {
        ed = DataTransition.EnemyFromFile(EnemyName);
        health = ed.health;
        AttackDamage = ed.AttackDamage;
        ui = GameObject.Find("UI").GetComponent<UI>();
        m_animator = GameObject.Find(EnemyName + "(Clone)").GetComponent<Animator>();
    }
    public void Set_Death()
    {
        if (!Pausemenu.GameisPaused)
        {
            m_animator.SetTrigger("Death");
        }
    }
    public void Set_Hurt()
    {
        if (!Pausemenu.GameisPaused )
        {
            m_animator.SetTrigger("Hurt");

        }
    }
    public void Set_Idle()
    {
            // Prevents flickering transitions to idle
            m_delayToIdle -= Time.deltaTime;
            if (m_delayToIdle < 0)
            { }
    }
    public void Set_Attack()
    {
        if (!Pausemenu.GameisPaused)
        {
            m_animator.SetTrigger("Attack");

        }
    }
}
