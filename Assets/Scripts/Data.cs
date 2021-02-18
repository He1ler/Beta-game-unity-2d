using UnityEngine;

[System.Serializable]
public class Data
{
    public string mapName;
    public int heroIndex1;
    public int heroIndex2;
    public Data (HeroSelector hs)
    {
        mapName = hs.MapName;
        heroIndex1 = hs.heroSelect1;
        heroIndex2 = hs.heroSelect2;
    }
}
