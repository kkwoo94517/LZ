using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICoalMine : UIResearchHouse
{
    public override HouseType HouseType => HouseType.CoalMine;

    [SerializeField] public UICoalMineDetail UIDetail;

    public void OnClick_Detail()
    {
        base.OnClick_Detail("¼®Åº ±¤»ê");

        UIDetail.gameObject.SetActive(true);

        if (!IsLoadDone)
        {
            IsLoadDone = true;
            UIDetail.LoadDataRewards();
        }
    }
}
