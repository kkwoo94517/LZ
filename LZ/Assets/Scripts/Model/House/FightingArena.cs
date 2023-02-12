using System.Collections.Generic;


// 일정 주민수를 넘어서면 나타나는 도박 컨텐츠
public class FightingArena : ResearchBuilding
{
    public long Seed { get; set; }
    public List<FightingArenaHistory> History { get; set; }
    // 보상 목록 (바로 받아가지 않을 것은 대비하여, 여러 목록으로 보일 수 있게)
}

public class FightingArenaHistory
{
    public int Round { get; set; }
    public int RedTeamPeopleId { get; set; }
    public int BlueTeamPeopleId { get; set; }
    public int ReceiveRewardDay { get; set; }
    // 승자
    // 보상 목록
}