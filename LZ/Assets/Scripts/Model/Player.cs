
using System.Collections.Generic;

public class Player
{
    // 현재 챕터
    public int Chapter { get; set; }

    // 현재 날짜
    public int Date { get; private set; } = 0;

    // 오늘 날의 상태
    public DayType DayType { get; private set; } = DayType.Night;

    // 현재 체력
    public int CurrentHP { get; set; }

    // 최대 체력
    public int MaxHP { get; set; }

    // 불의 세기
    public int FireRate { get; set; }

    // 현재 온도
    public int Temperature { get; set; }

    // 배고픔
    public int Hungry { get; set; }

    public Inventory Inventory { get; set; }

    public Player()
    {

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
}