using UnityEngine;

[System.Serializable]
public class Enemy {
	public GameObject EnemyObject;
    public string EnemyName;
	const int size = 1;

	public int MaxHealth = 100;
	public int health = 100;
    public int AttackDamage = 10;
}
