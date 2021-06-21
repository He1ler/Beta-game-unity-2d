//Script for some bosses
//Moving unit to the point including animationes
using UnityEngine;

public class CrabScript : MonoBehaviour
{
    public string Bossname;
    public float m_speed = 150.0f;
    public Vector3 walkingChangeXY1 = new Vector3(140, -155, 0);
    public float size = 0;

    private Animator m_animator;
    private bool target = false;
    public Transform groundDetection;
    private float lenght = 0.0f;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        m_animator = GameObject.Find(Bossname + "(Clone)").GetComponent<Animator>();
        m_animator.SetTrigger("Attack");
        lenght = m_animator.GetCurrentAnimatorStateInfo(0).length;
    }
    void Update ()
    {
        //Start moving
        if (!Pausemenu.GameisPaused && !target)
        {
            lenght -= Time.deltaTime*size;
            if (lenght<=0)
            {
                m_animator.SetTrigger("Attack");
                lenght = m_animator.GetCurrentAnimatorStateInfo(0).length;
            }
            transform.position = Vector2.MoveTowards(transform.position, walkingChangeXY1, m_speed * Time.deltaTime);
            if (groundDetection.position == walkingChangeXY1)
            {
                target = true;
            }
        }
    }
}
