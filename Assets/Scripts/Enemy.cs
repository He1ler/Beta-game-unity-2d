using UnityEngine;

[System.Serializable]
public class Enemy {
	public GameObject EnemyObject;
    public string EnemyName;
	const int size = 1;

	public int MaxHealth = 100;
	public int health = 100;
    public int AttackDamage = 10;

	public bool isDead = false;

    public int Attack()
    {
        return AttackDamage;
    }
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

        //Exp += worth;
        /* GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
         Destroy(effect, 5f);

         WaveSpawner.EnemiesAlive--;

         Destroy(gameObject);*/
    }
}
