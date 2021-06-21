// Script for all units (heroes,krips,projectiles)
// Makes normal posisoning of models with ground
using UnityEngine;

public class Sensor : MonoBehaviour {

    private int m_ColCount = 0;

    private float m_DisableTimer;
    //starting
    private void OnEnable()
    {
        m_ColCount = 0;
    }
    //chek
    public bool State()
    {
        if (m_DisableTimer > 0)
            return false;
        return m_ColCount > 0;
    }
    //not used
    void OnTriggerEnter2D(Collider2D other)
    {
        m_ColCount++;
    }
    //not used
    void OnTriggerExit2D(Collider2D other)
    {
        m_ColCount--;
    }
  
    void Update()
    {
        m_DisableTimer -= Time.deltaTime;
    }
    //disable for limit time
    public void Disable(float duration)
    {
        m_DisableTimer = duration;
    }
}
