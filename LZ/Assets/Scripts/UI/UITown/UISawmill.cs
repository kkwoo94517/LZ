using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISawmill : UIResearchHouse
{
    public override HouseType HouseType => HouseType.Sawmill;

    [SerializeField] public UISawmillDetail UIDetail;

    public void OnClick_Detail()
    {
        base.OnClick_Detail("�����");

        UIDetail.gameObject.SetActive(true);
        
        if (!IsLoadDone)
        {
            IsLoadDone = true;
            UIDetail.LoadDataRewards();
        }
    }
}
