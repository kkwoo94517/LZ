using System;
using System.Collections.Generic;

public class PlayerStatus
{
    public int Level { get; set; } = 1;
    public int Exp { get; set; } = 100;
    public int Gold { get; set; } = 0;

    public int CurrentHP { get; set; }
    public int MaxHP { get; set; }
    public int CurrentSearch { get; set; }
    public int MaxSearch { get; set; }
    

    public int Food { get; set; }
    public int Wood { get; set; }
    public int Coal { get; set; }
    public int Herb { get; set; }
    public int STR { get; set; }
    public int WIS { get; set; }
    public int CHA { get; set; }

    public PlayerStatus(CharacterStatusEntity statusEntity, CharacterLevelEntity levelEntity)
    {
        CurrentHP = levelEntity.HP;
        MaxHP = levelEntity.HP;
        CurrentSearch = levelEntity.Search;
        MaxSearch = levelEntity.Search;

        Gold = statusEntity.Gold;
        Wood = statusEntity.Wood;
        Food = statusEntity.Food;
        Coal = statusEntity.Coal;
        Herb = statusEntity.Herb;
        STR = statusEntity.STR;
        WIS = statusEntity.WIS;
        CHA = statusEntity.CHA;

        Level = levelEntity.Level;
        Exp = levelEntity.Exp;
    }
}