using System.Collections.Generic;
using System.Linq;

public class Town
{
    // 중심 열피
    public ThermalHull ThermalHull { get; set; }
    // 거주지
    public House House { get; set; }
    // 저장소
    public Stockpiles Stockpiles { get; set; }
    // 진료소
    public MedicalPost MedicalPost { get; set; }
    // 연구소
    public Laboratory Laboratory { get; set; }
    // 판매 상점
    public SaleShop SaleShop { get; set; }
    // 임무지
    public TownMission TownMission { get; set; }
    // 결투장
    public FightingArena FightingArena { get; set; }
    // 취사장
    public Cookhouse Cookhouse { get; set; }
    // 제재소
    public Sawmill Sawmill { get; set; }
    // 석탄 광산
    public CoalMine CoalMine { get; set; }

    public Town()
    {
        ThermalHull = new ThermalHull();
    }

    public void Initialize()
    {
        ThermalHull.Initialize();
    }
}

public class ResearchBuilding
{
    public int Level { get; set; }
    public int NeedOpenLevel { get; set; }
    public bool IsOpen => Level >= NeedOpenLevel;
}