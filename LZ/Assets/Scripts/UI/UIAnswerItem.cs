using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnswerItem : MonoBehaviour
{
    public int Index = 0;
    public float WaitSeconds = 0.2f;


    public void SetAnswerText(string title, string describe, string property, bool isEnable)
    {
        TitleText.text = title;
        PropertyText.text = property;
        DescribeText.text = describe;

        EnableText(isEnable);
        StartCoroutine(Co_Slide());
    }

    public void DisableAnswerItem()
    {
        TitleText.text = string.Empty;
        PropertyText.text = string.Empty;
        DescribeText.text = string.Empty;
        SelectBG.color = Color.gray;
    }

    public void SelectItem(int index)
    {
        SelectBG.color = index == Index ? Color.yellow : Color.gray;
    }

    private void EnableText(bool isEnable)
    {
        TitleText.color = isEnable ? Color.white : Color.gray;
        PropertyText.color = isEnable ? EnableColor : Color.gray;
        DescribeText.color = isEnable ? Color.white : Color.gray;
    }

    private IEnumerator Co_Slide()
    {
        AnswerBG.fillAmount = 1;
        AnswerBG.gameObject.SetActive(true);
        yield return new WaitForSeconds(WaitSeconds);

        while (AnswerBG.fillAmount >= 0.02f)
        {
            yield return new WaitForEndOfFrame();
            AnswerBG.fillAmount -= Time.deltaTime;
        }

        AnswerBG.fillAmount = 0f;
        AnswerBG.gameObject.SetActive(false);
        yield break;
    }


    [SerializeField] private Text TitleText;
    [SerializeField] private Text PropertyText;
    [SerializeField] private Text DescribeText;
    [SerializeField] private Color EnableColor;

    [SerializeField] private Image AnswerBG;
    [SerializeField] private Image SelectBG;
}
