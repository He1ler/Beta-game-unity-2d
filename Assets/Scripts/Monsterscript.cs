using UnityEngine;

public class Monsterscript : MonoBehaviour
{
    private Animator m_animator;
    private float m_delayToIdle = 0.0f;
    UI ui;
    public string EnemyName;
    public int health;
    public int AttackDamage;
    public int MaxHealth;
    public bool IsDead = false;
    private EnemyData ed;
    void Start()
    {
        ed = DataTransition.EnemyFromFile(EnemyName);
        health = ed.health;
        MaxHealth = ed.health;
        AttackDamage = ed.AttackDamage;
        ui = GameObject.Find("UI").GetComponent<UI>();
        m_animator = GameObject.Find(EnemyName + "(Clone)").GetComponent<Animator>();
    }
    public void Set_Death()
    {
        if (!Pausemenu.GameisPaused)
        {
            m_animator.SetTrigger("Death");
            IsDead = true;
        }
    }
    public void Set_Hurt(int hp)
    {
        if (!Pausemenu.GameisPaused && (!IsDead))
        {
            m_animator.SetTrigger("Hurt");
            health -= hp;
            if(health<=0)
            {
                health = 0;
                Set_Death();
            }
        }
    }
    public void Set_Idle()
    {
        if (!Pausemenu.GameisPaused && (!IsDead))
        {
            // Prevents flickering transitions to idle
            m_delayToIdle -= Time.deltaTime;
            if (m_delayToIdle < 0)
            { }
        }
    }
    public void Set_Attack()
    {
        if (!Pausemenu.GameisPaused &&(!ui.hero.IsDead))
        {
            m_animator.SetTrigger("Attack");
            ui.hero.Set_Hurt(AttackDamage);
        }
    }
}
