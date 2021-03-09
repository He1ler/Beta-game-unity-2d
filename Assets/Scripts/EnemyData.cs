using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public int health;
    public int AttackDamage;
    public EnemyData(Enemy ws)
    {
        health = ws.health;
        AttackDamage = ws.AttackDamage;
    }
}
