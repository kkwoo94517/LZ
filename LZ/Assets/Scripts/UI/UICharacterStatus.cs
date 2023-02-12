using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterStatus : MonoBehaviour
{
    public void RefreshHP()
    {
        var current = GameManager.Instance.Player.CurrentHP;

        var max = GameManager.Instance.Player.MaxHP;

        HPGague.fillAmount = current / max;
    }



    [SerializeField] private Text SearchLevelText;
    [SerializeField] private Text SearchExpText;

    [SerializeField] private Image HPGague;
    [SerializeField] private Text HPGagueText;
    [SerializeField] private Image SearchGague;
    [SerializeField] private Text SearchGagueText;

    [SerializeField] private Text STRText;
    [SerializeField] private Text WISText;
    [SerializeField] private Text CHAText;

    [SerializeField] private Text FoodText;
    [SerializeField] private Text CoalText;
    [SerializeField] private Text HerbText;
}
