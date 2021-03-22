using UnityEngine;

public class CrabScript : MonoBehaviour
{
    [SerializeField] float m_speed = 100.0f;
    private Animator m_animator;
    private Vector3 walkingChangeXY1 = new Vector3(140, -140, 0);
    private bool target = false;
    // Use this for initialization
    void Start()
    {
        m_animator = GameObject.Find("CrabBoss" + "(Clone)").GetComponent<Animator>();
        while (!Pausemenu.GameisPaused && !target)
        {
            transform.position = Vector2.MoveTowards(transform.position, walkingChangeXY1, m_speed * Time.deltaTime);
            m_animator.SetTrigger("Attack");
        }
    }
}
