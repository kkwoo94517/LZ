
using System;
using System.Collections.Generic;

public class Player
{
    public int Stage { get; set; } = 1;
    public int Date { get; set; } = 1;
    public DayType DayType { get; private set; } = DayType.Night;
    
    public int Temperature { get; set; } = 0;
    public int Happiness { get; set; } = 100;
    public int UnHappiness { get; set; } = 0;

    public PlayerStatus Status { get; set; }

    public Town Town { get; set; }

    public Inventory Inventory { get; set; }

    public List<People> Party { get; set; }

    public Player(CharacterStatusEntity statusEntity, CharacterLevelEntity levelEntity)
    {
        Town = new Town();
        Inventory = new Inventory();
        Party = new List<People>();

        Status = new PlayerStatus(statusEntity, levelEntity);
    }

    public void SetNextTime()
    {
        DayType++;

        // 밤이 지났다면
        // 일자 증가 및 다시 새벽으로
        if (DayType > DayType.Night)
        {
            Date++;
            DayType = DayType.Dawn;
        }
    }

    public void RecoveryHP(int amount)
    {
        Status.CurrentHP = Math.Max(Status.CurrentHP + amount, Status.MaxHP);
    }
}