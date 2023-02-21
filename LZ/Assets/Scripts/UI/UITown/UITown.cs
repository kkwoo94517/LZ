using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITown : MonoBehaviour
{
    [SerializeField] public UITownList UITownList;
    [SerializeField] public UIThermalHull UIThermalHull;

    [SerializeField] public UIMedicalPost UIMedicalPost;
    [SerializeField] public UIStockpiles UIStockpiles;
    [SerializeField] public UIHouse UIHouse;
    [SerializeField] public UISawmill UISawmill;
    [SerializeField] public UICoalMine UICoalMine;
    [SerializeField] public UISaleShop UISaleShop;
    [SerializeField] public UICookhouse UICookhouse;

    public void SetDetailTitle(string title)
    {
        DetailTitle.text = title;
    }

    public void SetDetailIcon(Sprite sprite)
    {
        if (sprite == null)
        {
            DetailIcon.sprite = DefaultIcon;
        }
        else
        {
            DetailIcon.sprite = sprite;
        }
    }

    public void OnClick_DisableTownList()
    {
        TurnOffActive();
        UITownList.Disable();
    }

    public void TurnOffActive()
    {
        UIMedicalPost.UIDetail.gameObject.SetActive(false);
        UIThermalHull.UIDetail.gameObject.SetActive(false);
        UIStockpiles.UIDetail.gameObject.SetActive(false);
        UIHouse.UIDetail.gameObject.SetActive(false);
        UISawmill.UIDetail.gameObject.SetActive(false);
        UICoalMine.UIDetail.gameObject.SetActive(false);
        UISaleShop.UIDetail.gameObject.SetActive(false);
        UICookhouse.UIDetail.gameObject.SetActive(false);
    }


    [SerializeField] private Text DetailTitle;
    [SerializeField] private Image DetailIcon;
    [SerializeField] private Sprite DefaultIcon;
}
