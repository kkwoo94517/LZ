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
}

[Serializable]
public class CharacterLevelEntity
{
    public int UniqueId;
    public int Level;
    public int Exp;
    public int HP;
    public int Search;
}

