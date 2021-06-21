//Enemy data which save health and damage of enemy unit into data variable "EnemyData"

[System.Serializable]
public class EnemyData
{
    public int health;
    public int AttackDamage;
    public EnemyData(Enemy ws)//save health and damage of enemy unit into data
    {
        health = ws.health;
        AttackDamage = ws.AttackDamage;
    }
}
