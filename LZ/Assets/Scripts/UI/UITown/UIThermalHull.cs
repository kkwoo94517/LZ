using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIThermalHull : MonoBehaviour
{
    [SerializeField] public UIThermalHullDetail UIDetail;
    [SerializeField] private Text PreviewText;

    public void OnClick_Detail()
    {
        UIManager.Instance.UITown.SetDetailTitle("중심 타워");
        UIManager.Instance.UITown.SetDetailIcon(null);
        UIManager.Instance.UITown.TurnOffActive();

        UIDetail.gameObject.SetActive(true);
    }

    private void SetPreviewEnergy(string text)
    {
        var splite = PreviewText.text.Split(',')[1];

        // 현재 연료 적음, 추가된 석탄 없음
        PreviewText.text = $"{text}, {splite}";
    }

    private void SetPreviewCoalAmount(string text)
    {
        var splite = PreviewText.text.Split(',')[0];

        // 현재 연료 적음, 추가된 석탄 없음
        PreviewText.text = $"{splite}, {text}";
    }

    public void RefreshEnergy()
    {

    }

    public void RefreshCoalAmountText(int amount)
    {
        if (amount >= 1)
        {
            SetPreviewCoalAmount($"석탄 {amount}개 추가됨");
        }
        else
        {
            SetPreviewCoalAmount("추가된 석탄 없음");
        }
    }
}
