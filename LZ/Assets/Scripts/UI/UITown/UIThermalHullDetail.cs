using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIThermalHullDetail : MonoBehaviour
{
    private bool IsCoalFull => ActiveInputCoal >= InputCoalList.Count;
    private int ActiveInputCoal => InputCoalList.Count(e => e.enabled);

    public void RefreshGague()
    {
        float defaultValue = 0.01f;

        TemperatureAfter.fillAmount = defaultValue * GameManager.Instance.Player.Town.ThermalHull.Energy;
        TemperatureCurrent.fillAmount = defaultValue * GameManager.Instance.Player.Town.ThermalHull.DayByEnergy(0);
        TemperatureNextDay.fillAmount = defaultValue * 20;
    }    

    public void OnClick_AddCoal()
    {
        if (IsCoalFull)
        {
            return;
        }

        var amount = GameManager.Instance.Player.Town.ThermalHull.AddCoal();

        InputCoalList[amount - 1].enabled = true;

        RefreshGague();
        UIManager.Instance.UITown.UIThermalHull.RefreshCoalAmountText(amount);
    }

    public void OnClick_RemoveCoal(int index)
    {
        if (ActiveInputCoal == 0)
        {
            return;
        }

        if (!InputCoalList[index].enabled)
        {
            return;
        }

        var amount = GameManager.Instance.Player.Town.ThermalHull.RemoveCoal();

        InputCoalList[amount].enabled = false;

        RefreshGague();
        UIManager.Instance.UITown.UIThermalHull.RefreshCoalAmountText(amount);
    }

    public void Clear()
    {
        InputCoalList.ForEach(e => e.enabled = false);

    }

    [SerializeField] private Image TemperatureAfter;
    [SerializeField] private Image TemperatureCurrent;
    [SerializeField] private Image TemperatureNextDay;
    [SerializeField] private Text TemperatureText;

    [SerializeField] private Text CurrentCoalText;
    [SerializeField] private List<Image> InputCoalList;

    [SerializeField] private Sprite CoalIcon;
}

