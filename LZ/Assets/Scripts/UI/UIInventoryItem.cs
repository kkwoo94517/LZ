using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] private Image IconSprite;
    [SerializeField] private Text CountText;
    [SerializeField] private Text WeightText;

    public int SlotIndex { get; set; }

    public void SetSlotIndex(int index)
    {
        SlotIndex = index;
    }

    public void ActiveItem(bool isActive)
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(isActive);
        }
    }

    public void SetCountText(int count)
    {
        CountText.text = $"{count}";
    }

    public void SetWeightText(float weight)
    {
        string weightString = string.Format("{0:F1}", weight);

        WeightText.text = $"{weightString} kg";
    }

    public void DeactiveWeight()
    {
        WeightText.transform.parent.gameObject.SetActive(false);
    }
}
