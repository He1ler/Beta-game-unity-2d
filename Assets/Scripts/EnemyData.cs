//Enemy data which save health and damage of enemy unit into data variable "EnemyData"

[System.Serializable]
public class EnemyData
{
    public int health;
    public int AttackDamage;
    //public int Currenthp;
    public EnemyData(Enemy ws)//save max health and damage of enemy unit into data
    {
        health = ws.MaxHealth;
        AttackDamage = ws.AttackDamage;
        //Currenthp = ws.health;
    }
    // public EnemyData(int ws)//save current health of enemy unit into data
    // {
    //     Currenthp = ws;
    // }
}
