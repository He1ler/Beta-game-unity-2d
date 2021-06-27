// Data for game variables

[System.Serializable]
public class GameData
{
    public string mapName;
    public int heroIndex1;
    public int heroIndex2;
    public int enemyIndex1;
    public int enemyIndex2;
    public int enemyIndex3;
    public int enemyIndex4;
    public int enemyPosition1;
    public int enemyPosition2;
    public int enemyPosition3;
    public int enemyPosition4;
    public bool Isboss;
    public bool IsLoading;
    public bool IsNewGame;
    public int Waves;
    public int EnemiesAlive;
    public BattleState turns;
    public GameData(HeroSelector hs)// saving variables for loading level
    {
        mapName = hs.MapName;
        heroIndex1 = hs.heroSelect1;
        heroIndex2 = hs.heroSelect2;
        Isboss = hs.Isboss;
        IsLoading = false;
    }
    public GameData(string mapName)// saving level name for loading level
    {
        this.mapName = mapName;
           heroIndex1= 0;
      heroIndex2= 0;
      enemyIndex1= 0;
      enemyIndex2= 0;
      enemyIndex3= 0;
      enemyIndex4= 0;
      enemyPosition1= 0;
      enemyPosition2= 0;
      enemyPosition3= 0;
      enemyPosition4= 0;
      Isboss= false;
      IsLoading= false;
      IsNewGame= false;
      Waves= 0;
      EnemiesAlive= 0;
     turns= BattleState.Waiting;
}
    public GameData(bool IsLoading, bool IsNewGame)//if player will load game this variable will point it
    {
        this.IsLoading = IsLoading;
        this.IsNewGame = IsNewGame;
    }

    public GameData(int i1, int i2, int i3, int i4, int Waves, int EA, BattleState turns,int pos1, int pos2,int pos3,int pos4)//Game data for loading level
    {
        enemyIndex1 = i1;
        enemyIndex2 = i2;
        enemyIndex3 = i3;
        enemyIndex4 = i4;
        this.Waves = Waves;
        EnemiesAlive = EA;
        this.turns = turns;
        enemyPosition1 = pos1;
        enemyPosition2 = pos2;
        enemyPosition3 = pos3;
        enemyPosition4 = pos4;
}
}
