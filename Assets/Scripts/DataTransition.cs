using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataTransition
{
    public static void MapNameToFile(HeroSelector hs)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Name.map";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        GameData GameData = new GameData(hs);
        formatter.Serialize(stream, GameData);
        stream.Close();
    }
    public static GameData MapNameFromFile()
    {
        string path = Application.persistentDataPath + "/Name.map";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData GameData = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return GameData;
        }
        else
        {
            Debug.LogError("file doesnt exist");
            return null;
        }   
    }

    public static void HeroToFile(int i,Hero []hero)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + hero[i].HeroName + ".hero";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        HeroData GameData = new HeroData(hero[i]);
        formatter.Serialize(stream, GameData);
        stream.Close();
    }
    public static HeroData HeroFromFile(string HeroName)
    {
        string path = Application.persistentDataPath + "/" + HeroName + ".hero";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            HeroData GameData = formatter.Deserialize(stream) as HeroData;
            stream.Close();

            return GameData;
        }
        else
        {
            Debug.LogError("file doesnt exist");
            return null;
        }
    }
    public static void EnemyToFile(int i, Enemy[] enemy)
    {
        string path = Application.persistentDataPath + "/" + enemy[i].EnemyName + ".enemy";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        EnemyData GameData = new EnemyData(enemy[i]);
        formatter.Serialize(stream, GameData);
        stream.Close();
    }
    public static EnemyData EnemyFromFile(string EnemyName)
    {
        string path = Application.persistentDataPath + "/" + EnemyName + ".enemy";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            EnemyData GameData = formatter.Deserialize(stream) as EnemyData;
            stream.Close();

            return GameData;
        }
        else
        {
            Debug.LogError("file doesnt exist");
            return null;
        }
    }
}
