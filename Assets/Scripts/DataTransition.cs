using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class DataTransition
{
    public static void MapNameToFile(HeroSelector hs)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Name.map";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        Data data = new Data(hs);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static Data MapNameFromFile()
    {
        string path = Application.persistentDataPath + "/Name.map";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Data data = formatter.Deserialize(stream) as Data;
            stream.Close();

            return data;
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
        HeroData data = new HeroData(hero[i]);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static HeroData HeroFromFile(string HeroName)
    {
        string path = Application.persistentDataPath + "/" + HeroName + ".hero";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            HeroData data = formatter.Deserialize(stream) as HeroData;
            stream.Close();

            return data;
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
        EnemyData data = new EnemyData(enemy[i]);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static EnemyData EnemyFromFile(string EnemyName)
    {
        string path = Application.persistentDataPath + "/" + EnemyName + ".enemy";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            EnemyData data = formatter.Deserialize(stream) as EnemyData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("file doesnt exist");
            return null;
        }
    }
}
