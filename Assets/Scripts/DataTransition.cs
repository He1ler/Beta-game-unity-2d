// Script which save some data in the file inside the folder of game
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataTransition
{
    public static void MapNameToFile(HeroSelector hs)//saving level name from special data format(In the choosing level window) to file for next loading
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Name.map";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        GameData GameData = new GameData(hs);
        formatter.Serialize(stream, GameData);
        stream.Close();
    }
    public static void MapNameToFileMenu(string MapName)//saving level name straight from string variable to file for next loading in the main menu
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Name.map";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        GameData GameData = new GameData(MapName);
        formatter.Serialize(stream, GameData);
        stream.Close();
    }
    public static GameData MapNameFromFile() //load level name and level data from file into the GameData variable
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
        else // check for safety
        {
            Debug.LogError("file doesnt exist");
            return null;
        }   
    }

    public static void HeroToFile(int i,Hero []hero) //saving Hero name from special data format(In the choosing heroes window) to file for next loading
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + hero[i].HeroName + ".hero";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        HeroData GameData = new HeroData(hero[i]);
        formatter.Serialize(stream, GameData);
        stream.Close();
    }
    public static HeroData HeroFromFile(string HeroName)//load Hero name from file into the sting variable
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
        else// check for safety
        {
            Debug.LogError("file doesnt exist");
            return null;
        }
    }
    public static void EnemyToFile(int i, Enemy[] enemy) //saving all enemies names from special data format to file for next loading
    {
        string path = Application.persistentDataPath + "/" + enemy[i].EnemyName + ".enemy";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        EnemyData GameData = new EnemyData(enemy[i]);
        formatter.Serialize(stream, GameData);
        stream.Close();
    }
    public static EnemyData EnemyFromFile(string EnemyName)//load enemy name from file into the sting variable
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
        else// check for safety
        {
            Debug.LogError("file doesnt exist");
            return null;
        }
    }
}
