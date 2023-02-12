using System.Collections.Generic;

// 전체 물건을 구매하고, 연구용 약초와 교환한다.
// 추우면 비싼 가격에 아이템을 구매
public class SaleShop : ResearchBuilding
{
    public int Percentage { get; set; }
    // 구매 이력
    Dictionary<int, int> SaleItemHistory { get; set; }
    // 약초 구매 횟수
    public int MedicinalHerbsPurchaseCount { get; set; }
}