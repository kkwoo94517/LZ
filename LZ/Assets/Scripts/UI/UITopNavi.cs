using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITopNavi : MonoBehaviour
{
    [SerializeField] private Image DateIcon;
    [SerializeField] private Text DateText;

    public void Refresh()
    {
        var player = GameManager.Instance.Player;

        Happiness.fillAmount = player.Happiness / CommonConst.MAX_HAPPINESS;
        UnHappiness.fillAmount = player.UnHappiness / CommonConst.MAX_HAPPINESS;
    }

    public void SetDateUI(DayType dayType, int date)
    {
        StartCoroutine(Co_ChangeDay(dayType, date));
    }

    public void ChargeHappiness()
    {
        float goal = GameManager.Instance.Player.Happiness / (float)CommonConst.MAX_HAPPINESS;

        StartCoroutine(Co_RefreshTopNavi(Happiness, goal));
    }

    public void ChargeUnHappiness()
    {
        float goal = GameManager.Instance.Player.UnHappiness / (float)CommonConst.MAX_UNHAPPINESS;

        StartCoroutine(Co_RefreshTopNavi(UnHappiness, goal));
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

    private IEnumerator Co_RefreshTopNavi(Image image, float goal)
    {
        var fill = image.fillAmount < goal ? Time.deltaTime : -Time.deltaTime;

        if (fill < 0)
        {
            while (image.fillAmount >= goal)
            {
                yield return new WaitForEndOfFrame();
                image.fillAmount += fill * .6f;
            }
        }
        else
        {
            while (image.fillAmount <= goal)
            {
                yield return new WaitForEndOfFrame();
                image.fillAmount += fill * .6f;
            }
        }

        image.fillAmount = goal;
    }

    [SerializeField] private Image Happiness;
    [SerializeField] private Image UnHappiness;


    [SerializeField] private Sprite DawnSprite;
    [SerializeField] private Sprite DawnToDaySprite;
    [SerializeField] private Sprite DaySprite;
    [SerializeField] private Sprite DayToNightSprite;
    [SerializeField] private Sprite NightSprite;
    [SerializeField] private Sprite NightToDawnSprite;
}
