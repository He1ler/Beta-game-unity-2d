[System.Serializable]
public class Data
{
    public string mapName;
    public int heroIndex1;
    public int heroIndex2;
    public bool Isboss;
    public Data (HeroSelector hs)
    {
        mapName = hs.MapName;
        heroIndex1 = hs.heroSelect1;
        heroIndex2 = hs.heroSelect2;
        Isboss = hs.Isboss;
    }
}
