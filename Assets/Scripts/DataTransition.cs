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
}
