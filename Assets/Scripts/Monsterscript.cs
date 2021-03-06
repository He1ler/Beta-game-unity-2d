using UnityEngine;
using UnityEngine.UI;

public class Monsterscript : MonoBehaviour
{
    private Animator m_animator;
    private float m_delayToIdle = 0.0f;
    UI ui;
    void Start()
    {
         ui = GameObject.Find("UI").GetComponent<UI>();
         m_animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (!Pausemenu.GameisPaused && ui.enemy.EnemyState == EnemyStates.Dead)
        {
            m_animator.SetTrigger("Death");
        }
        //Hurt
        else if (!Pausemenu.GameisPaused && (ui.hero.HeroState == HeroStates.Skill1 || ui.hero.HeroState == HeroStates.Skill2 || ui.hero.HeroState == HeroStates.Skill3 || ui.hero.HeroState == HeroStates.Skill4))
        {
            m_animator.SetTrigger("Hurt"); 
        }

        else if (!Pausemenu.GameisPaused && ui.enemy.EnemyState == EnemyStates.Attack)
        {
            ui.hero.TakeDamage(ui.enemy.AttackDamage);
            m_animator.SetTrigger("Attack"); 
        }

        else
        {
            // Prevents flickering transitions to idle
            m_delayToIdle -= Time.deltaTime;
            if (m_delayToIdle < 0)
            { }
        }
    }

}
