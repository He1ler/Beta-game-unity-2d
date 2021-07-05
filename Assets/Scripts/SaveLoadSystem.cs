using UnityEngine;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{
    public GameData CurrentData;
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/Name.map"))
        {
            TransitDataToCurrent();
        }
        else
        {
            NewData();
            SaveDataIntoFile();
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void NewData()
    {
        CurrentData = new GameData();
    }
    public GameData TransitDataToCurrent()
    {
        CurrentData = new GameData(DataTransition.MapNameFromFile());
        return CurrentData;
    }
    public void SaveDataIntoFile()
    {
        DataTransition.MapNameToFile(CurrentData);
    }
    public void SaveLevelName(string str)
    {
        CurrentData.mapName = str;
        DataTransition.MapNameToFile(CurrentData);
    }
    public void SaveDataForLoadLevel(HeroSelector hs)
    {
        CurrentData.mapName = hs.MapName;
        CurrentData.heroIndex1 = hs.heroSelect1;
        CurrentData.heroIndex2 = hs.heroSelect2;
        CurrentData.Isboss = hs.Isboss;
        DataTransition.MapNameToFile(CurrentData);
    }
    public void LoadOrNewGame(bool Load,bool New)
    {
        CurrentData.IsLoading = Load;
        CurrentData.IsNewGame = New;
        DataTransition.MapNameToFile(CurrentData);
    }
    public void SaveEnemiesdata(int i1, int i2, int i3, int i4, int Waves, int EA )
    {
        CurrentData.Waves = Waves;
        CurrentData.EnemiesAlive = EA;
        CurrentData.enemyIndex1 = i1;
        CurrentData.enemyIndex2 = i2;
        CurrentData.enemyIndex3 = i3;
        CurrentData.enemyIndex4 = i4;
        DataTransition.MapNameToFile(CurrentData);
    }
    public void SaveHp(int i1, int i2, int i3, int i4, int ii5, int ii6)
    {
        CurrentData.enemyhp1 = i1;
        CurrentData.enemyhp2 = i2;
        CurrentData.enemyhp3 = i3;
        CurrentData.enemyhp4 = i4;
        CurrentData.herohp1 = ii5;
        CurrentData.herohp2 = ii6;
        DataTransition.MapNameToFile(CurrentData);
    }

}
