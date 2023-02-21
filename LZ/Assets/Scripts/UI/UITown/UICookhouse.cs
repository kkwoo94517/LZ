using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICookhouse : UIResearchHouse
{
    public override HouseType HouseType => HouseType.Cookhouse;

    [SerializeField] public UICookhouseDetail UIDetail;

    public void OnClick_Detail()
    {
        base.OnClick_Detail("√ÎªÁ¿Â");

        UIDetail.gameObject.SetActive(true);

        if (!IsLoadDone)
        {
            IsLoadDone = true;
            UIDetail.LoadDataCookList();
        }
    }
}
