using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHistoryItem : MonoBehaviour
{
    [SerializeField] private Image ItemIcon;
    [SerializeField] private Text TitleText;
    [SerializeField] private Text DescribeText;

    public void SetHistoryItem(Sprite sprite, string title, string describe)
    {
        ItemIcon.sprite = sprite;
        TitleText.text = title;
        DescribeText.text = describe;
    }
}
