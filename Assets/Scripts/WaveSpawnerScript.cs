// Script for spawning waves and etc on level
using UnityEngine;
using System.Linq;
public class WaveSpawnerScript : MonoBehaviour
{
	public Vector3 EnemyPosition1 = new Vector3(50, -140, 0);
	public Vector3 EnemyPosition2 = new Vector3(150, -140, 0);
	public Vector3 EnemyPosition3 = new Vector3(250, -140, 0);
	public Vector3 EnemyPosition4 = new Vector3(350, -140, 0);
	public Vector3 HeroPosition1 = new Vector3(-150, -140, 0);
	public Vector3 HeroPosition2 = new Vector3(-330, -140, 0);
	public Vector3 BossPosition = new Vector3(300, -140, 0);

	public int waveIndex = 0;
	public int EnemiesAlive = 0;
	private int EnemyNumber;

	public Enemy [] enemies;
	public Enemy [] Bosses;
	public Hero  [] heroes;

	public Hero hero1;
	public Hero hero2;

	public Enemy enemy1;
	public Enemy enemy2;
	public Enemy enemy3;
	public Enemy enemy4;

	public bool IsBoss = false;

	private int [] RandomEnemies = Enumerable.Range(0, 28).ToArray();
	void Start()//load from files data for heroes and level
	{
		Time.timeScale = 1;
		if (DataTransition.MapNameFromFile().IsNewGame)
		{
			NewGame();
		}
		hero1 = heroes[DataTransition.MapNameFromFile().heroIndex1 - 1];
		hero2 = heroes[DataTransition.MapNameFromFile().heroIndex2 - 1];
		hero1.HeroObject.GetComponent<Player>().HeroName = hero1.HeroObject.name;
		hero2.HeroObject.GetComponent<Player>().HeroName = hero2.HeroObject.name;
		SpawnHero(hero1.HeroObject, 1);
		GameObject.Find(hero1.HeroObject.name + "(Clone)").GetComponent<Player>().Attack1 = hero1.Attack1;
		GameObject.Find(hero1.HeroObject.name + "(Clone)").GetComponent<Player>().Attack2 = hero1.Attack2;
		GameObject.Find(hero1.HeroObject.name + "(Clone)").GetComponent<Player>().Attack3 = hero1.Attack3;
		GameObject.Find(hero1.HeroObject.name + "(Clone)").GetComponent<Player>().Attack4 = hero1.Attack4;
		GameObject.Find(hero1.HeroObject.name + "(Clone)").GetComponent<Player>().Death = hero1.Death;
		SpawnHero(hero2.HeroObject, 2);
		GameObject.Find(hero2.HeroObject.name + "(Clone)").GetComponent<Player>().Attack1 = hero2.Attack1;
		GameObject.Find(hero2.HeroObject.name + "(Clone)").GetComponent<Player>().Attack2 = hero2.Attack2;
		GameObject.Find(hero2.HeroObject.name + "(Clone)").GetComponent<Player>().Attack3 = hero2.Attack3;
		GameObject.Find(hero2.HeroObject.name + "(Clone)").GetComponent<Player>().Attack4 = hero2.Attack4;
		GameObject.Find(hero2.HeroObject.name + "(Clone)").GetComponent<Player>().Death = hero2.Death;
		IsBoss = DataTransition.MapNameFromFile().Isboss;
		if (DataTransition.MapNameFromFile().IsLoading)
		{
			LoadLevel();
		}
		else if (IsBoss)//if boss level, spawn boss,else spawn wave
		{
			EnemiesAlive = 1;
			waveIndex = 1;
			SpawnBoss();
		}
		else
		{
			SpawnWave();
		}

	}
	public void SpawnWave()//spawning waves
	{
		RandomEnemies = Enumerable.Range(0, 28).ToArray();
		EnemiesAlive = Random.Range(2, 5);//choosing random size of enemy party from 2 to 4
		for (int i = 1; i <= EnemiesAlive; i++)// radnomly choosing enemies from pool
		{
			EnemyNumber = Random.Range(0, enemies.Length);
			while (RandomEnemies[EnemyNumber] == -1)
			{
				EnemyNumber = Random.Range(0, enemies.Length);
			}//spawning enemies on positions from 1 to 4, saving enemies in file for next loading if it will be
			if (i == 1)
			{
				enemy1 = enemies[RandomEnemies[EnemyNumber]];
				RandomEnemies[EnemyNumber] = -1;
				enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
				SpawnEnemy(enemy1.EnemyObject, i);
				GameObject.Find(enemy1.EnemyName + "(Clone)").GetComponent<Monsterscript>().Attack = enemy1.Attack;
				GameObject.Find(enemy1.EnemyName + "(Clone)").GetComponent<Monsterscript>().Death = enemy1.Death;
			}
			else if (i == 2)
			{
				enemy2 = enemies[RandomEnemies[EnemyNumber]];
				RandomEnemies[EnemyNumber] = -1;
				enemy2.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy2.EnemyName;
				SpawnEnemy(enemy2.EnemyObject, i);
				GameObject.Find(enemy2.EnemyName + "(Clone)").GetComponent<Monsterscript>().Attack = enemy2.Attack;
				GameObject.Find(enemy2.EnemyName + "(Clone)").GetComponent<Monsterscript>().Death = enemy2.Death;
			}
			else if (i == 3)
			{
				enemy3 = enemies[RandomEnemies[EnemyNumber]];
				RandomEnemies[EnemyNumber] = -1;
				enemy3.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy3.EnemyName;
				SpawnEnemy(enemy3.EnemyObject, i);
				GameObject.Find(enemy3.EnemyName + "(Clone)").GetComponent<Monsterscript>().Attack = enemy3.Attack;
				GameObject.Find(enemy3.EnemyName + "(Clone)").GetComponent<Monsterscript>().Death = enemy3.Death;
			}
			else if (i == 4)
			{
				enemy4 = enemies[RandomEnemies[EnemyNumber]];
				RandomEnemies[EnemyNumber] = -1;
				enemy4.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy4.EnemyName;
				SpawnEnemy(enemy4.EnemyObject, i);
				GameObject.Find(enemy4.EnemyName + "(Clone)").GetComponent<Monsterscript>().Attack = enemy4.Attack;
				GameObject.Find(enemy4.EnemyName + "(Clone)").GetComponent<Monsterscript>().Death = enemy4.Death;
			}
		}
		waveIndex++;//rise index of waves (max 3 waves)
		SaveGame();
	}

	public void LoadLevel()//load level
	{
		EnemiesAlive = DataTransition.MapNameFromFile().EnemiesAlive;
		waveIndex = DataTransition.MapNameFromFile().Waves;
		for (int i = 1; i <= EnemiesAlive; i++)
		{
			//spawning enemies on positions from 1 to 4
			if (i == 1 && DataTransition.MapNameFromFile().enemyIndex1 != -1)
			{
				if (i == 1 && GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().TransitDataToCurrent().enemyhp1 > 0)
				{
					enemy1 = enemies[DataTransition.MapNameFromFile().enemyIndex1];
					enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
					SpawnEnemy(enemy1.EnemyObject,1);
					GameObject.Find(enemy1.EnemyName + "(Clone)").GetComponent<Monsterscript>().Attack = enemy1.Attack;
					GameObject.Find(enemy1.EnemyName + "(Clone)").GetComponent<Monsterscript>().Death = enemy1.Death;
				}
			}
			else if (i == 2 && DataTransition.MapNameFromFile().enemyIndex2 != -1)
			{
				if (i == 2 && GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().TransitDataToCurrent().enemyhp2 > 0)
				{
					enemy2 = enemies[DataTransition.MapNameFromFile().enemyIndex2];
					enemy2.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy2.EnemyName;
					SpawnEnemy(enemy2.EnemyObject,2);
					GameObject.Find(enemy2.EnemyName + "(Clone)").GetComponent<Monsterscript>().Attack = enemy2.Attack;
					GameObject.Find(enemy2.EnemyName + "(Clone)").GetComponent<Monsterscript>().Death = enemy2.Death;
				}
			}
			else if (i == 3 && DataTransition.MapNameFromFile().enemyIndex3 != -1)
			{
				if (i == 3 && GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().TransitDataToCurrent().enemyhp3 > 0)
				{
					enemy3 = enemies[DataTransition.MapNameFromFile().enemyIndex3];
					enemy3.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy3.EnemyName;
					SpawnEnemy(enemy3.EnemyObject,3);
					GameObject.Find(enemy3.EnemyName + "(Clone)").GetComponent<Monsterscript>().Attack = enemy3.Attack;
					GameObject.Find(enemy3.EnemyName + "(Clone)").GetComponent<Monsterscript>().Death = enemy3.Death;
				}
			}
			else if (i == 4 && DataTransition.MapNameFromFile().enemyIndex4 != -1)
			{
				if (i == 4 && GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().TransitDataToCurrent().enemyhp4 > 0)
				{
					enemy4 = enemies[DataTransition.MapNameFromFile().enemyIndex4];
					enemy4.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy4.EnemyName;
					SpawnEnemy(enemy4.EnemyObject,4);
					GameObject.Find(enemy4.EnemyName + "(Clone)").GetComponent<Monsterscript>().Attack = enemy4.Attack;
					GameObject.Find(enemy4.EnemyName + "(Clone)").GetComponent<Monsterscript>().Death = enemy4.Death;
				}
			}
		}
	}

	public void NewGame()
	{
		for (int i = 0; i < 8; i++)
		{
			DataTransition.HeroToFile(i, heroes);
		}
		for (int i = 0; i < 28; i++)
		{
			DataTransition.EnemyToFile(i, enemies);
		}
		for (int i = 0; i < 6; i++)
		{
			DataTransition.EnemyToFile(i, Bosses);
		}
		GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().LoadOrNewGame(false, false);
	}
	void SpawnBoss()//spawning boss only on boss locations
    {
		if(DataTransition.MapNameFromFile().mapName == "Castle3")
        {
			enemy1 = Bosses[0];
			enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
			Instantiate(Bosses[0].EnemyObject, BossPosition, Quaternion.identity);
		}
		else if (DataTransition.MapNameFromFile().mapName == "Cave3")
		{
			enemy1 = Bosses[1];
			enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
			Instantiate(Bosses[1].EnemyObject, BossPosition, Quaternion.identity);
		}
		else if (DataTransition.MapNameFromFile().mapName == "Church3")
        {
			enemy1 = Bosses[2];
			enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
			Instantiate(Bosses[2].EnemyObject, BossPosition, Quaternion.identity);
		}
		else if (DataTransition.MapNameFromFile().mapName == "Dungeon3")
		{
			enemy1 = Bosses[3];
			enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
			Instantiate(Bosses[3].EnemyObject, BossPosition, Quaternion.identity);
		}
		else if (DataTransition.MapNameFromFile().mapName == "Forest3")
		{
			enemy1 = Bosses[4];
			enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
			Instantiate(Bosses[4].EnemyObject, BossPosition, Quaternion.identity);
		}
		else if (DataTransition.MapNameFromFile().mapName == "Graveyard3")
		{
			enemy1 = Bosses[5];
			enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
			Instantiate(Bosses[5].EnemyObject, BossPosition, Quaternion.identity);
		}
	}
	void SpawnEnemy(GameObject enemy,int n)//spawn choosed enemy
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
	void SpawnHero(GameObject hero, int n)//spawn hero
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
	void SaveGame()
    {
		int[] IndexsArrays = {-1,-1,-1,-1};
		int j = 0;
		for (int i=0; i<28;i++)
        {
			if(RandomEnemies[i]==-1)
            {
				IndexsArrays[j] = i;
				j++;
            }
        }
		GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().SaveEnemiesdata(IndexsArrays[0], IndexsArrays[1], IndexsArrays[2], IndexsArrays[3], waveIndex, EnemiesAlive);
		if (IsBoss || EnemiesAlive == 1)
		{ GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().SaveHp(GameObject.Find(enemy1.EnemyName + "(Clone)").GetComponent<Monsterscript>().health, 0, 0, 0, GameObject.Find(hero1.HeroObject.name + "(Clone)").GetComponent<Player>().health, GameObject.Find(hero2.HeroObject.name + "(Clone)").GetComponent<Player>().health); }
		else if (EnemiesAlive == 2)
		{ GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().SaveHp(GameObject.Find(enemy1.EnemyName + "(Clone)").GetComponent<Monsterscript>().health, GameObject.Find(enemy2.EnemyName + "(Clone)").GetComponent<Monsterscript>().health, 0, 0, GameObject.Find(hero1.HeroObject.name + "(Clone)").GetComponent<Player>().health, GameObject.Find(hero2.HeroObject.name + "(Clone)").GetComponent<Player>().health); }
		else if (EnemiesAlive == 3)
		{ GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().SaveHp(GameObject.Find(enemy1.EnemyName + "(Clone)").GetComponent<Monsterscript>().health, GameObject.Find(enemy2.EnemyName + "(Clone)").GetComponent<Monsterscript>().health, GameObject.Find(enemy3.EnemyName + "(Clone)").GetComponent<Monsterscript>().health,0, GameObject.Find(hero1.HeroObject.name + "(Clone)").GetComponent<Player>().health, GameObject.Find(hero2.HeroObject.name + "(Clone)").GetComponent<Player>().health); }
		else
		{ GameObject.Find("SaveLoadSystem").GetComponent<SaveLoadSystem>().SaveHp(GameObject.Find(enemy1.EnemyName + "(Clone)").GetComponent<Monsterscript>().health, GameObject.Find(enemy2.EnemyName + "(Clone)").GetComponent<Monsterscript>().health, GameObject.Find(enemy3.EnemyName + "(Clone)").GetComponent<Monsterscript>().health, GameObject.Find(enemy4.EnemyName + "(Clone)").GetComponent<Monsterscript>().health, GameObject.Find(hero1.HeroObject.name + "(Clone)").GetComponent<Player>().health, GameObject.Find(hero2.HeroObject.name + "(Clone)").GetComponent<Player>().health); }
		

	}
}
