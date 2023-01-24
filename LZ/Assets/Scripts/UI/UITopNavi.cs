using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITopNavi : MonoBehaviour
{
    [SerializeField] private Image DateIcon;
    [SerializeField] private Text DateText;


    public void SetDateUI(DayType dayType, int date)
    {
        StartCoroutine(Co_ChangeDay(dayType, date));
    }

    /// <summary>
    /// 현재 시간에 맞게 아이콘이 변경됩니다.
    /// </summary>
    private void SetDateIcon(DayType dayType, bool isDone)
    {
        switch (dayType)
        {
            case DayType.Dawn:
                if (isDone)
                {
                    DateIcon.sprite = DawnSprite;
                }
                else
                {
                    DateIcon.sprite = NightToDawnSprite;
                }
                break;
            case DayType.Day:
                if (isDone)
                {
                    DateIcon.sprite = DaySprite;
                }
                else
                {
                    DateIcon.sprite = DawnToDaySprite;
                }
                break;
            case DayType.Night:
                if (isDone)
                {
                    DateIcon.sprite = NightSprite;
                }
                else
                {
                    DateIcon.sprite = DayToNightSprite;
                }
                break;
        }
    }

    private IEnumerator Co_ChangeDay(DayType day, int date)
    {
        yield return new WaitForSeconds(0.2f);
        SetDateIcon(day, false);
        yield return new WaitForSeconds(0.2f);
        SetDateIcon(day, true);

        DateText.text = $"{date}일차\n{day}";
    }

    [SerializeField] private Sprite DawnSprite;
    [SerializeField] private Sprite DawnToDaySprite;
    [SerializeField] private Sprite DaySprite;
    [SerializeField] private Sprite DayToNightSprite;
    [SerializeField] private Sprite NightSprite;
    [SerializeField] private Sprite NightToDawnSprite;
}
