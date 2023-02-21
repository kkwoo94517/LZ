using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterStatus : MonoBehaviour
{
    public void Refresh()
    {
        var player = GameManager.Instance.Player;

        LevelText.text = player.Status.Level.ToString();
        ExpText.text = player.Status.Exp.ToString();

        HPGague.fillAmount = player.Status.CurrentHP / player.Status.MaxHP;
        HPGagueText.text = $"{player.Status.CurrentHP} / {player.Status.MaxHP}";
        SearchGague.fillAmount = player.Status.CurrentSearch / player.Status.MaxSearch;
        SearchGagueText.text = $"{player.Status.CurrentSearch} / {player.Status.MaxSearch}";

        STRText.text = $"�ٷ� : {player.Status.STR}";
        WISText.text = $"���� : {player.Status.WIS}";
        CHAText.text = $"�ŷ� : {player.Status.CHA}";

        FoodText.text = $"���� : {player.Status.Food}";
        WoodText.text = $"���� : {player.Status.Wood}";
        CoalText.text = $"��ź : {player.Status.Coal}";
        HerbText.text = player.Status.Herb.ToString();
        GoldText.text = player.Status.Gold.ToString();
    }

    [SerializeField] private Text LevelText;
    [SerializeField] private Text ExpText;

    [SerializeField] private Image HPGague;
    [SerializeField] private Text HPGagueText;
    [SerializeField] private Image SearchGague;
    [SerializeField] private Text SearchGagueText;

    [SerializeField] private Text STRText;
    [SerializeField] private Text WISText;
    [SerializeField] private Text CHAText;

    [SerializeField] private Text FoodText;
    [SerializeField] private Text WoodText;
    [SerializeField] private Text CoalText;
    [SerializeField] private Text HerbText;
    [SerializeField] private Text GoldText;
}
