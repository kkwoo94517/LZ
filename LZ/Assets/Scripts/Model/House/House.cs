using System.Collections.Generic;
using System.Linq;

// 주민들의 거주지
public class House : ResearchBuilding
{
    // 주민들
    public List<People> Peoples = new List<People>();
    // 현재 거주 중인 주민 수
    public int PeopleCount => Peoples?.Select(e => e.OnTown).Count() ?? 0;
}