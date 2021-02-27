using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Hero
{
	public GameObject HeroObject;
	public string HeroName;
	public Sprite HeroImage;

   /* public Image Skill1Image;
    public Image Skill2Image;
    public Image Skill3Image;
    public Image Skill4Image;
    public string Skill1Name;
    public string Skill2Name;
    public string Skill3Name;
    public string Skill4Name;*/

    public int MaxHealth = 100;
    public int health = 100;

    public int Skill1Damage=10;
    public int Skill2Damage=15;
    public int Skill3Damage=20;
    public int Skill4Damage=30;

    public bool isDead=false;

    public void TakeDamage(int amount)
    {
       health -= amount;

       if (health <= 0 && !isDead)
       {
           Die();
       }
    }
    public void Die()
    {
        isDead = true;
    }
    public int Skill1()
    {
        return Skill1Damage;
    }
    public int Skill2()
    {
        return Skill1Damage;
    }
    public int Skill3()
    {
        return Skill1Damage;
    }
    public int Skill4()
    {
        return Skill1Damage;
    }
}
