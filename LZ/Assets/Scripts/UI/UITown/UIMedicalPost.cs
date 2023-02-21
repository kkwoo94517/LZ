using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMedicalPost : UIResearchHouse
{
    public override HouseType HouseType => HouseType.MedicalPost;

    [SerializeField] public UIMedicalPostDetail UIDetail;

    public void OnClick_Detail()
    {
        base.OnClick_Detail("진료소");

        UIDetail.gameObject.SetActive(true);
        UIDetail.RefreshMedicalPeople();
    }
}
