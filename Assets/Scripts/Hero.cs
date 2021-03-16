using UnityEngine;

[System.Serializable]
public class Hero
{
	public GameObject HeroObject;
	public string HeroName;
	public Sprite HeroImage;

    public Sprite Skill1Image;
    public Sprite Skill2Image;
    public Sprite Skill3Image;
    public Sprite Skill4Image;
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

}
