using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITown : MonoBehaviour
{
    [SerializeField] private Text DetailTitle;
    [SerializeField] public UITownList UITownList;
    [SerializeField] public UIMedicalPost UIMedicalPost;
    [SerializeField] public UIThermalHull UIThermalHull;

    public void SetDetailTitle(string title)
    {
        DetailTitle.text = title;
    }

    public void OnClick_DisableTownList()
    {
        TurnOffActive();
        UITownList.Disable();
    }

    public void TurnOffActive()
    {

        UIThermalHull.UIDetail.gameObject.SetActive(false);
    }    
}
