using System;

[Serializable]
public class CharacterStatusEntity
{
    public int UniqueId;
    public int STR;
    public int WIS;
    public int CHA;
    public int Gold;
    public int Food;
    public int Wood;
    public int Herb;
    public int Coal;
    public int PeopleCount;
    public int InventoryWeight;

    public CharacterStatusEntity() { }
    public CharacterStatusEntity(CharacterStatusEntity data)
    {
        UniqueId = data.UniqueId;
        STR = data.STR;
        WIS = data.WIS;
        CHA = data.CHA;
        Gold = data.Gold;
        Food = data.Food;
        Wood = data.Wood;
        Herb = data.Herb;
        Coal = data.Coal;
        PeopleCount = data.PeopleCount;
        InventoryWeight = data.InventoryWeight;
    }
}

[Serializable]
public class CharacterLevelEntity
{
    public int UniqueId;
    public int Level;
    public int Exp;
    public int HP;
    public int Search;

    public CharacterLevelEntity() { }

    public CharacterLevelEntity(CharacterLevelEntity data)
    {
        UniqueId = data.UniqueId;
        Level = data.Level;
        Exp = data.Exp;
        HP = data.HP;
        Search = data.Search;
    }
}

