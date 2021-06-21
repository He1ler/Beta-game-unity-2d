// Data for game variables

[System.Serializable]
public class GameData
{
    public string mapName;
    public int heroIndex1;
    public int heroIndex2;
    public bool Isboss;
    public GameData(HeroSelector hs)// saving variables for loading level
    {
        mapName = hs.MapName;
        heroIndex1 = hs.heroSelect1;
        heroIndex2 = hs.heroSelect2;
        Isboss = hs.Isboss;
    }
    public GameData(string mapName)// saving level name for loading level
    {
        this.mapName = mapName;
        heroIndex1 = 0;
        heroIndex2 = 0;
        Isboss = false;
    }
}
