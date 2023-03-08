using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    public delegate void ChangeUIFunc();

    /// <summary>
    /// 화면 전환
    /// </summary>
    public void ChangeUI(DayType day, ChangeUIFunc func)
    {
        StartCoroutine(Co_AniBG(MainBG, func));
        StartCoroutine(Co_AniBG(CardBG, null));

        switch (day)
        {
            case DayType.Dawn:
                UIManager.Instance.UIEventStory.ClearStory();
                UIManager.Instance.UIAnswer.ClearAnswerItems();

                UIManager.Instance.UIEventStory.LoadEventStory();
                ActiveEvent();
                UIManager.Instance.UIEventStory.ShowEventStory();
                break;
            case DayType.Day:
                //UIManager.Instance.UIHistory.ClearHistory();

                UIManager.Instance.UIGameMap.LoadGameMap();
                ActiveSlots();
                break;
            case DayType.Night:

                UIManager.Instance.UITown.LoadTown();
                ActiveTown();
                break;
        }
    }

    /// <summary>
    /// 시간 변경에 따른 화면 전환
    /// </summary>
    private IEnumerator Co_AniBG(Image image, ChangeUIFunc func)
    {
        float progress = 0; float duration = 10f; float increment = 0.02f / duration;
        
        image.raycastTarget = false;
        image.gameObject.SetActive(true);
        image.color = Color.black;
        yield return new WaitForEndOfFrame();

        while (progress < 1)
        {
            image.color = Color.Lerp(Color.black, Color.clear, progress);
            progress += increment;
            yield return new WaitForEndOfFrame();
        }

        image.raycastTarget = true;
        image.gameObject.SetActive(false);

        func?.Invoke();

        yield return null;
    }

    private void ActiveEvent()
    {
        EventStory.SetActive(true);
        SelectCard.SetActive(true);

        GameMap.SetActive(false);
        History.SetActive(false);
        Town.SetActive(false);
        Detail.SetActive(false);
    }

    private void ActiveSlots()
    {
        GameMap.SetActive(true);
        History.SetActive(true);

        EventStory.SetActive(false);
        SelectCard.SetActive(false);
        Town.SetActive(false);
        Detail.SetActive(false);
    }

    private void ActiveTown()
    {
        Town.SetActive(true);
        Detail.SetActive(true);

        GameMap.SetActive(false);
        History.SetActive(false);
        EventStory.SetActive(false);
        SelectCard.SetActive(false);
    }

    [SerializeField] private GameObject EventStory;
    [SerializeField] private GameObject SelectCard;

    [SerializeField] private GameObject GameMap;
    [SerializeField] private GameObject History;

    [SerializeField] private GameObject Town;
    [SerializeField] private GameObject Detail;

    [SerializeField] private Image MainBG;
    [SerializeField] private Image CardBG;
}
