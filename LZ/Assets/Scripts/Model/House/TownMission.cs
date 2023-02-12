using System;
using System.Collections.Generic;

// 인게임 전용 일반 임무지
public class TownMission : ResearchBuilding
{
    // 현재 진행 가능한 미션
    public List<int> AvailableIds { get; set; }
}

public class MissionProgress
{
    // 기본적으로 일반 미션은 인게임에서만 진행하도록
    public int UniqueId { get; set; }
    public bool IsComplete { get; set; }
    public string Type { get; set; }
    public long Amount { get; set; }
}

public class MissionHistory
{
    public int UniqueId { get; set; }
    public DateTime CompleteTime { get; set; }
}