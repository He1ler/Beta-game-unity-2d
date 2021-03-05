using UnityEngine;
public class WaveSpawnerScript : MonoBehaviour
{
	public Vector3 EnemyPosition1 = new Vector3(38, 193, 0);
	public Vector3 EnemyPosition2 = new Vector3(178, 193, 0);
	public Vector3 EnemyPosition3 = new Vector3(38, 193, 0);
	public Vector3 EnemyPosition4 = new Vector3(178, 193, 0);
	public Vector3 HeroPosition1 = new Vector3(38, 193, 0);
	public Vector3 HeroPosition2 = new Vector3(178, 193, 0);

	public int waveIndex = 0;
	public int EnemiesAlive = 0;
	private int EnemyNumber;

	public Enemy []enemies;
	public Hero[]heroes;

	public Hero hero1;
	public Hero hero2;

	public Enemy enemy1;
	public Enemy enemy2;
	public Enemy enemy3;
	public Enemy enemy4;

	public bool IsBoss = false;

	void Start()
    {
		hero1 = heroes[DataTransition.MapNameFromFile().heroIndex1 - 1];
		hero2 = heroes[DataTransition.MapNameFromFile().heroIndex2 - 1];
		SpawnHero(hero1.HeroObject, 1);
		SpawnHero(hero2.HeroObject, 2);
		SpawnWave();
	}
	public void SpawnWave()
	{
		EnemiesAlive = Random.Range(2,5);
		for (int i = 1; i <= EnemiesAlive; i++)
		{
			EnemyNumber = Random.Range(0, enemies.Length);
			if(i==1)
            {
				enemy1 = enemies[EnemyNumber];
				SpawnEnemy(enemy1.EnemyObject, i);
			}
			else if (i == 2)
			{
				enemy2 = enemies[EnemyNumber];
				SpawnEnemy(enemy2.EnemyObject, i);
			}
			else if (i == 3)
			{
				enemy3 = enemies[EnemyNumber];
				SpawnEnemy(enemy3.EnemyObject, i);
			}
			else if (i == 4)
			{
				enemy4 = enemies[EnemyNumber];
				SpawnEnemy(enemy4.EnemyObject, i);
			}
		}
		waveIndex++;
	}
	void SpawnEnemy(GameObject enemy,int n)
	{
		if(n==1)
        {
			Instantiate(enemy, EnemyPosition1, Quaternion.identity);
		}
		else if (n == 2)
		{
			Instantiate(enemy, EnemyPosition2, Quaternion.identity);
		}
		else if(n == 3)
		{
			Instantiate(enemy, EnemyPosition3, Quaternion.identity);
		}
		else if(n == 4)
		{
			Instantiate(enemy, EnemyPosition4, Quaternion.identity);
		}
	}
	void SpawnHero(GameObject hero, int n)
    {
		if (n == 1)
		{
			Instantiate(hero, HeroPosition1, Quaternion.identity);
		}
		else if (n == 2)
		{
			Instantiate(hero, HeroPosition2, Quaternion.identity);
		}
	}
}
