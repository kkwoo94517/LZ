using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISaleShopOwnItem : MonoBehaviour
{
    [SerializeField] private Image Icon;
    [SerializeField] private Text AmountText;

    private int UniqueId = 0;
    private int Amount = 0;

    public void Initialize()
    {
        UniqueId = 0;
        Icon.enabled = false;

        this.GetComponent<Button>().enabled = false;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void SetItem(int uniqueId, int amount)
    {
        UniqueId = uniqueId;
        Icon.enabled = true;
        // TODO : 아이템 불러오기

        SetAmountText(amount);

        this.GetComponent<Button>().enabled = true;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void OnClick_OnSale()
    {
        if (Amount <= 0) { return; }


        Amount--;
        SetAmountText(Amount);
    }

    private void SetAmountText(int amount)
    {
        AmountText.text = amount.ToString();
    }
}
