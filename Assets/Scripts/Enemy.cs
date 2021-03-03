using UnityEngine;

public enum EnemyStates { Waiting,Dead, Attack};
[System.Serializable]
public class Enemy {
    public EnemyStates EnemyState = EnemyStates.Waiting;

	public GameObject EnemyObject;
    public string EnemyName;
	const int size = 1;

	public int MaxHealth = 100;
	public int health = 100;
    public int AttackDamage = 10;


    public int Attack()
    {
        EnemyState = EnemyStates.Attack;
        return AttackDamage;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0 && EnemyState == EnemyStates.Dead)
        {
            Die();
        }
    }
    public void Die()
    {
        EnemyState = EnemyStates.Dead;

        //Exp += worth;
        /* GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
         Destroy(effect, 5f);

         WaveSpawner.EnemiesAlive--;

         Destroy(gameObject);*/
    }
}
