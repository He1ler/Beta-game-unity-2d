using UnityEngine;

[System.Serializable]
public class HeroData
{
    public int health;
    public int Skill1Damage;
    public int Skill2Damage;
    public int Skill3Damage;
    public int Skill4Damage;
    public HeroData(Hero ws)
    {
        health = ws.health;
        Skill1Damage = ws.Skill1Damage;
        Skill2Damage = ws.Skill2Damage;
        Skill3Damage = ws.Skill3Damage;
        Skill4Damage = ws.Skill4Damage;
    }
}
