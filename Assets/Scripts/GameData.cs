// Data for game variables

[System.Serializable]
public class GameData
{
    public string mapName;
    public int heroIndex1;
    public int heroIndex2;
    public int herohp1;
    public int herohp2;
    public int enemyIndex1;
    public int enemyIndex2;
    public int enemyIndex3;
    public int enemyIndex4;
    public int enemyhp1;
    public int enemyhp2;
    public int enemyhp3;
    public int enemyhp4;
    public bool Isboss;
    public bool IsLoading;
    public bool IsNewGame;
    public int Waves;
    public int EnemiesAlive;
    public GameData()// saving starting variables for new game
    {
        mapName = "";
        heroIndex1 = 0;
        heroIndex2 = 0;
        Isboss = false;
        IsLoading = false;
        enemyIndex1 = 0;
        enemyIndex2 = 0;
        enemyIndex3 = 0;
        enemyIndex4 = 0;
        IsNewGame = true;
        Waves = 0;
        EnemiesAlive = 0;
        enemyhp1  = 0;
        enemyhp2  = 0;
        enemyhp3  = 0;
        enemyhp4 = 0;
        herohp1 = 0;
        herohp2 = 0;
    }
    public GameData(GameData hs)// saving variables for loading level
    {
        mapName = hs.mapName;
        heroIndex1 = hs.heroIndex1;
        heroIndex2 = hs.heroIndex2;
        Isboss = hs.Isboss;
        IsLoading = hs.IsLoading;
        enemyIndex1 = hs.enemyIndex1;
        enemyIndex2 = hs.enemyIndex2;
        enemyIndex3 = hs.enemyIndex3;
        enemyIndex4 = hs.enemyIndex4;
        IsNewGame = hs.IsNewGame;
        Waves = hs.Waves;
        EnemiesAlive = hs.EnemiesAlive;
        enemyhp1 = hs.enemyhp1;
        enemyhp2 = hs.enemyhp2;
        enemyhp3 = hs.enemyhp3;
        enemyhp4 = hs.enemyhp4;
        herohp1 = hs.herohp1;
        herohp2 = hs.herohp2;
    }
 //   public GameData(HeroSelector hs)// saving variables for loading level
 //   {
 //       mapName = hs.MapName;
 //       heroIndex1 = hs.heroSelect1;
 //       heroIndex2 = hs.heroSelect2;
 //       Isboss = hs.Isboss;
 //       IsLoading = false;
 //       enemyIndex1 = 0;
 //       enemyIndex2 = 0;
 //       enemyIndex3 = 0;
 //       enemyIndex4 = 0;
 //       IsNewGame = false;
 //       Waves = 0;
 //       EnemiesAlive = 0;
 //   }
 //   public GameData(string mapName)// saving level name for loading level
 //   {
 //       this.mapName = mapName;
 //       heroIndex1 = 0;
 //       heroIndex2 = 0;
 //       Isboss = false;
 //       IsLoading = false;
 //       enemyIndex1 = 0;
 //       enemyIndex2 = 0;
 //       enemyIndex3 = 0;
 //       enemyIndex4 = 0;
 //       IsNewGame = false;
 //       Waves = 0;
 //       EnemiesAlive = 0;
 //   }
 //   public GameData(bool IsLoading, bool IsNewGame)//if player will load game this variable will point it
 //   {
 //       this.IsLoading = IsLoading;
 //       this.IsNewGame = IsNewGame;
 //       if (IsNewGame)
 //       {
 //           mapName = "Hub location";
 //           heroIndex1 = 0;
 //           heroIndex2 = 0;
 //           Isboss = false;
 //           enemyIndex1 = 0;
 //           enemyIndex2 = 0;
 //           enemyIndex3 = 0;
 //           enemyIndex4 = 0;
 //           Waves = 0;
 //           EnemiesAlive = 0;
 //       }
 //       if(IsLoading)
 //       {
 //           mapName = DataTransition.MapNameFromFile().mapName;
 //           heroIndex1 = DataTransition.MapNameFromFile().heroIndex1;
 //           heroIndex2 = DataTransition.MapNameFromFile().heroIndex2;
 //           Isboss = DataTransition.MapNameFromFile().Isboss;
 //           enemyIndex1 = DataTransition.MapNameFromFile().enemyIndex1;
 //           enemyIndex2 = DataTransition.MapNameFromFile().enemyIndex2;
 //           enemyIndex3 = DataTransition.MapNameFromFile().enemyIndex3;
 //           enemyIndex4 = DataTransition.MapNameFromFile().enemyIndex4;
 //           Waves = DataTransition.MapNameFromFile().Waves;
 //           EnemiesAlive = DataTransition.MapNameFromFile().EnemiesAlive;
 //       }
 //   }
 //
 //   public GameData(int i1, int i2, int i3, int i4, int Waves, int EA)//Game data for loading level
 //   {
 //       mapName = DataTransition.MapNameFromFile().mapName;
 //       heroIndex1 = DataTransition.MapNameFromFile().heroIndex1;
 //       heroIndex2 = DataTransition.MapNameFromFile().heroIndex2;
 //       Isboss = DataTransition.MapNameFromFile().Isboss;
 //       enemyIndex1 = i1;
 //       enemyIndex2 = i2;
 //       enemyIndex3 = i3;
 //       enemyIndex4 = i4;
 //       this.Waves = Waves;
 //       EnemiesAlive = EA;
 //       IsLoading = false;
 //       IsNewGame = false;
 //   }
}
