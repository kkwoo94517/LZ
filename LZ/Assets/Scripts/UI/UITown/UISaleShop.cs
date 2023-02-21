using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISaleShop : UIResearchHouse
{
    public override HouseType HouseType => HouseType.SaleShop;

    [SerializeField] public UISaleShopDetail UIDetail;

    public void OnClick_Detail()
    {
        base.OnClick_Detail("ªÛ¡°");

        UIDetail.gameObject.SetActive(true);
        UIDetail.RefreshOwnItems();
    }
}
