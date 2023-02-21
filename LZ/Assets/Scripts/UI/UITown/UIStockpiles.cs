using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStockpiles : UIResearchHouse
{
    public override HouseType HouseType => HouseType.Stockpiles;

    [SerializeField] public UIStockpilesDetail UIDetail;

    public void OnClick_Detail()
    {
        base.OnClick_Detail("¿˙¿Âº“");

        UIDetail.gameObject.SetActive(true);
        UIDetail.RefreshInventoryItems();
    }
}
