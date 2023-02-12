using System.Collections.Generic;


// 부상자 회복소
public class MedicalPost : ResearchBuilding
{
    // 나무 갯수
    public int WoodAmount { get; set; }
    // 가동 에너지
    public int Energy { get; set; }
    public List<People> WoundedPeople { get; set; }
}