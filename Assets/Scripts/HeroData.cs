//Hero data which save health and damage of Hero unit into data variable "HeroData"
[System.Serializable]
public class HeroData
{
    public int health;
    public int Skill1Damage;
    public int Skill2Damage;
    public int Skill3Damage;
    public int Skill4Damage;
    //public int Currenthp;
    public HeroData(Hero ws)//save health and damage of Hero unit into data
    {
        health = ws.MaxHealth;
        Skill1Damage = ws.Skill1Damage;
        Skill2Damage = ws.Skill2Damage;
        Skill3Damage = ws.Skill3Damage;
        Skill4Damage = ws.Skill4Damage;
    }
  // public HeroData(int ws)//save current health of hero unit into data
  // {
  //     Currenthp = ws;
  // }
}
