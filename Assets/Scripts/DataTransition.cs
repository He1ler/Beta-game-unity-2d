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

    public static void IsLoadToFileMenu(bool Load,bool NewGame)//saving variable which will point player load level
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Name.map";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        GameData GameData = new GameData(Load,NewGame);
        formatter.Serialize(stream, GameData);
        stream.Close();
    }

    public static void HeroToFile(int i,Hero []hero) //saving Hero from special data format(In the choosing heroes window) to file for next loading
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + hero[i].HeroName + ".hero";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        HeroData GameData = new HeroData(hero[i]);
        formatter.Serialize(stream, GameData);
        stream.Close();
    }
    public static void HeroHPToFile(string hero, int hp) //saving current hp for loading of heroes from special data format to file for next loading
    {
        string path = Application.persistentDataPath + "/" + hero + ".hero";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        HeroData GameData = new HeroData(hp);
        formatter.Serialize(stream, GameData);
        stream.Close();
    }
    public static HeroData HeroFromFile(string HeroName)//load Hero from file into the sting variable
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
    public static void EnemyToFile(int i, Enemy[] enemy) //saving all enemies from special data format to file for next loading
    {
        string path = Application.persistentDataPath + "/" + enemy[i].EnemyName + ".enemy";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        EnemyData GameData = new EnemyData(enemy[i]);
        formatter.Serialize(stream, GameData);
        stream.Close();
    }
    public static void EnemyHPToFile(string enemy,int hp) //saving current hp for loading of enemies from special data format to file for next loading
    {
        string path = Application.persistentDataPath + "/" + enemy + ".enemy";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        EnemyData GameData = new EnemyData(hp);
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
    public static void SaveGame(int i1, int i2, int i3, int i4, int Waves, int EA, BattleState turns, int pos1, int pos2, int pos3, int pos4)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Name.map";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        GameData GameData = new GameData(i1, i2, i3, i4, Waves, EA, turns,pos1,pos2,pos3,pos4);
        formatter.Serialize(stream, GameData);
        stream.Close();
    }
}
