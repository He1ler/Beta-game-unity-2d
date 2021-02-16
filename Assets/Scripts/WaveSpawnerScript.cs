using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawnerScript : MonoBehaviour
{
	public Vector3 EnemyPosition1 = new Vector3(38, 193, 0);
	public Vector3 EnemyPosition2 = new Vector3(178, 193, 0);
	public Vector3 EnemyPosition3 = new Vector3(38, 193, 0);
	public Vector3 EnemyPosition4 = new Vector3(178, 193, 0);
	public Vector3 HeroPosition1 = new Vector3(38, 193, 0);
	public Vector3 HeroPosition2 = new Vector3(178, 193, 0);
	private int waveIndex = 0;
	public static int EnemiesAlive = 0;
	public bool IsBoss = false;
	private int EnemyNumber;
	private int HeroNumber;
	Enemies enemies;
	Heroes heroes;
	public UI ui;
	void Start()
    {
		for(int i=0; i < 2;i++)
        {
			HeroNumber = (ui.Hero[i]-1);
			SpawnHero(heroes.HeroClass[HeroNumber].HeroObject, i);
		}
    }
	void Update()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}
		if (waveIndex == 3)
		{
			ui.WinLevel();
			this.enabled = false;
		}
		if (EnemiesAlive <=0)
		{
			SpawnWave();
			return;
		}
	}
	void SpawnWave()
	{
		EnemiesAlive = Random.Range(2,4);
		for (int i = 0; i < EnemiesAlive; i++)
		{
			EnemyNumber = Random.Range(0, enemies.EnemyClass.Length);
			SpawnEnemy(enemies.EnemyClass[EnemyNumber].EnemyObject,i);
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
	void SpawnHero(GameObject enemy, int n)
    {
		if (n == 1)
		{
			Instantiate(enemy, HeroPosition1, Quaternion.identity);
		}
		else if (n == 2)
		{
			Instantiate(enemy, HeroPosition2, Quaternion.identity);
		}
	}
}
