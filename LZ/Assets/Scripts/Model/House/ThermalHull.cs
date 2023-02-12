// 마을의 온도를 담당하는 열피
using System.Collections.Generic;

public class ThermalHull : ResearchBuilding
{
    // 현재 온도
    public int Temperature { get; set; }
    // 현재 석탄 갯수
    public int CurrentCoalAmount { get; set; }
    // 오늘 넣을 석탄 갯수
    public int TodayInputCoalAmount { get; set; }
    // 가동 연료 에너지
    public int Energy => CurrentCoalAmount * 10;

    // Key : Day, Value : TodayInputCoalAmount 
    public Dictionary<int, int> History { get; set; } = new Dictionary<int, int>();

    // 날짜에 따른 석탄 갯수
    public int DayByCoalAmount(int day) => History[day];
    // 날짜에 따른 연료 에너지
    public int DayByEnergy(int day) => History[day] * 10;

    public void Initialize()
    {
        Level = 1;
        Temperature = 0;
        CurrentCoalAmount = 5;
        TodayInputCoalAmount = 0;

        History.Add(0, CurrentCoalAmount);
    }


    public int AddCoal()
    {
        TodayInputCoalAmount++;
        CurrentCoalAmount++;

        return TodayInputCoalAmount;
    }

    public int RemoveCoal()
    {
        TodayInputCoalAmount--;
        CurrentCoalAmount--;

        return TodayInputCoalAmount;
    }

    /// <summary>
    /// today는 넘어가기 전의 오늘
    /// </summary>
    /// <param name="today"></param>
    public void NextDay(int today)
    {
        History.Add(today, TodayInputCoalAmount);

        TodayInputCoalAmount = 0;
    }
}