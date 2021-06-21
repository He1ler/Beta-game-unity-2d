// Data for heroes
//propper data for propper hero unit saves in apropriate element of "Heroes" array
using UnityEngine;

[System.Serializable]
public class Hero
{
	public GameObject HeroObject;
    //data of hero for Player UI
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

    // characteristics of hero unit
    public int MaxHealth = 100;
    public int health = 100;

    public int Skill1Damage=10;
    public int Skill2Damage=15;
    public int Skill3Damage=20;
    public int Skill4Damage=30;

    //Sound of death and skills of hero unit
    public AudioClip Attack1;
    public AudioClip Attack2;
    public AudioClip Attack3;
    public AudioClip Attack4;
    public AudioClip Death;
}
