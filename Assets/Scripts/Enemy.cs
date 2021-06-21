// Data for enemies
//propper data for propper enemy unit saves in apropriate element of "Enemies" array
using UnityEngine;

[System.Serializable]
public class Enemy {
	// characteristics of enemy unit
	public GameObject EnemyObject;
    public string EnemyName;
	const int size = 1;

	public int MaxHealth = 100;
	public int health = 100;
    public int AttackDamage = 10;
	// sound of attacking or death of enemy unit
	public AudioClip Attack;
	public AudioClip Death;
}
