using UnityEngine;
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
	void Start()
    {
		Time.timeScale = 1;
		hero1 = heroes[DataTransition.MapNameFromFile().heroIndex1 - 1];
		hero2 = heroes[DataTransition.MapNameFromFile().heroIndex2 - 1];
		DataTransition.HeroToFile(DataTransition.MapNameFromFile().heroIndex1 - 1, heroes);
		DataTransition.HeroToFile(DataTransition.MapNameFromFile().heroIndex2 - 1, heroes);
		hero1.HeroObject.GetComponent<Player>().HeroName = hero1.HeroName;
		hero2.HeroObject.GetComponent<Player>().HeroName = hero2.HeroName;
		SpawnHero(hero1.HeroObject, 1);
		GameObject.Find(hero1.HeroName + "(Clone)").GetComponent<Player>().Attack1 = hero1.Attack1;
		GameObject.Find(hero1.HeroName + "(Clone)").GetComponent<Player>().Attack2 = hero1.Attack2;
		GameObject.Find(hero1.HeroName + "(Clone)").GetComponent<Player>().Attack3 = hero1.Attack3;
		GameObject.Find(hero1.HeroName + "(Clone)").GetComponent<Player>().Attack4 = hero1.Attack4;
		GameObject.Find(hero1.HeroName + "(Clone)").GetComponent<Player>().Death = hero1.Death;
		SpawnHero(hero2.HeroObject, 2);
		GameObject.Find(hero2.HeroName + "(Clone)").GetComponent<Player>().Attack1 = hero2.Attack1;
		GameObject.Find(hero2.HeroName + "(Clone)").GetComponent<Player>().Attack2 = hero2.Attack2;
		GameObject.Find(hero2.HeroName + "(Clone)").GetComponent<Player>().Attack3 = hero2.Attack3;
		GameObject.Find(hero2.HeroName + "(Clone)").GetComponent<Player>().Attack4 = hero2.Attack4;
		GameObject.Find(hero2.HeroName + "(Clone)").GetComponent<Player>().Death = hero2.Death;
		IsBoss = DataTransition.MapNameFromFile().Isboss;
		if (IsBoss)
        {
		EnemiesAlive = 1;
		SpawnBoss();
        }
        else
        {
			SpawnWave();
		}
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
				enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
				DataTransition.EnemyToFile(EnemyNumber, enemies);
				SpawnEnemy(enemy1.EnemyObject, i);
				GameObject.Find(enemy1.EnemyName + "(Clone)").GetComponent<Monsterscript>().Attack = enemy1.Attack;
				GameObject.Find(enemy1.EnemyName + "(Clone)").GetComponent<Monsterscript>().Death = enemy1.Death;
			}
			else if (i == 2)
			{
				enemy2 = enemies[EnemyNumber];
				enemy2.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy2.EnemyName;
				DataTransition.EnemyToFile(EnemyNumber, enemies);
				SpawnEnemy(enemy2.EnemyObject, i);
				GameObject.Find(enemy2.EnemyName + "(Clone)").GetComponent<Monsterscript>().Attack = enemy2.Attack;
				GameObject.Find(enemy2.EnemyName + "(Clone)").GetComponent<Monsterscript>().Death = enemy2.Death;
			}
			else if (i == 3)
			{
				enemy3 = enemies[EnemyNumber];
				enemy3.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy3.EnemyName;
				DataTransition.EnemyToFile(EnemyNumber, enemies);
				SpawnEnemy(enemy3.EnemyObject, i);
				GameObject.Find(enemy3.EnemyName + "(Clone)").GetComponent<Monsterscript>().Attack = enemy3.Attack;
				GameObject.Find(enemy3.EnemyName + "(Clone)").GetComponent<Monsterscript>().Death = enemy3.Death;
			}
			else if (i == 4)
			{
				enemy4 = enemies[EnemyNumber];
				enemy4.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy4.EnemyName;
				DataTransition.EnemyToFile(EnemyNumber, enemies);
				SpawnEnemy(enemy4.EnemyObject, i);
				GameObject.Find(enemy4.EnemyName + "(Clone)").GetComponent<Monsterscript>().Attack = enemy4.Attack;
				GameObject.Find(enemy4.EnemyName + "(Clone)").GetComponent<Monsterscript>().Death = enemy4.Death;
			}
		}
		waveIndex++;
	}
	void SpawnBoss()
    {
		if(DataTransition.MapNameFromFile().mapName == "Castle3")
        {
			enemy1 = Bosses[0];
			enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
			DataTransition.EnemyToFile(0, Bosses);
			Instantiate(Bosses[0].EnemyObject, BossPosition, Quaternion.identity);
		}
		else if (DataTransition.MapNameFromFile().mapName == "Cave3")
		{
			enemy1 = Bosses[1];
			enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
			DataTransition.EnemyToFile(1, Bosses);
			Instantiate(Bosses[1].EnemyObject, BossPosition, Quaternion.identity);
		}
		else if (DataTransition.MapNameFromFile().mapName == "Church3")
        {
			enemy1 = Bosses[2];
			enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
			DataTransition.EnemyToFile(2, Bosses);
			Instantiate(Bosses[2].EnemyObject, BossPosition, Quaternion.identity);
		}
		else if (DataTransition.MapNameFromFile().mapName == "Dungeon3")
		{
			enemy1 = Bosses[3];
			enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
			DataTransition.EnemyToFile(3, Bosses);
			Instantiate(Bosses[3].EnemyObject, BossPosition, Quaternion.identity);
		}
		else if (DataTransition.MapNameFromFile().mapName == "Forest3")
		{
			enemy1 = Bosses[4];
			enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
			DataTransition.EnemyToFile(4, Bosses);
			Instantiate(Bosses[4].EnemyObject, BossPosition, Quaternion.identity);
		}
		else if (DataTransition.MapNameFromFile().mapName == "Graveyard3")
		{
			enemy1 = Bosses[5];
			enemy1.EnemyObject.GetComponent<Monsterscript>().EnemyName = enemy1.EnemyName;
			DataTransition.EnemyToFile(5, Bosses);
			Instantiate(Bosses[5].EnemyObject, BossPosition, Quaternion.identity);
		}
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
