using UnityEngine;
using UnityEngine.UI;

 public enum HeroStates { Waiting,Dead, Recovery, Skill1, Skill2, Skill3, Skill4 };
[System.Serializable]
public class Hero
{
    public HeroStates HeroState = HeroStates.Waiting;
	public GameObject HeroObject;
	public string HeroName;
	public Sprite HeroImage;

    public Image Skill1Image;
    public Image Skill2Image;
    public Image Skill3Image;
    public Image Skill4Image;
    public string Skill1Name;
    public string Skill2Name;
    public string Skill3Name;
    public string Skill4Name;

    public int MaxHealth = 100;
    public int health = 100;

    public int Skill1Damage=10;
    public int Skill2Damage=15;
    public int Skill3Damage=20;
    public int Skill4Damage=30;

    public void TakeDamage(int amount)
    {
       health -= amount;

       if (health <= 0 && HeroState == HeroStates.Dead)
       {
           Die();
       }
    }
    public void Recovery()
    {
        health += (MaxHealth / 10);
        if(health >= MaxHealth)
        {
            HeroState = HeroStates.Recovery;
        }
    }
    public void Die()
    {
        HeroState = HeroStates.Dead;
    }
    public int Skill1()
    {
        HeroState = HeroStates.Skill1;
        return Skill1Damage;
    }
    public int Skill2()
    {
        HeroState = HeroStates.Skill2;
        return Skill1Damage;
    }
    public int Skill3()
    {
        HeroState = HeroStates.Skill3;
        return Skill1Damage;
    }
    public int Skill4()
    {
        HeroState = HeroStates.Skill4;
        return Skill1Damage;
    }
}
