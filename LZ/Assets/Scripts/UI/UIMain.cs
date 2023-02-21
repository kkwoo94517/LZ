using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

                ActiveEvent(true);
                ActiveSlots(false);
                break;
            case DayType.Day:
            case DayType.Night:
                UIManager.Instance.UIHistory.ClearHistory();
                UIManager.Instance.UISlot.ClearSlotItems();

                ActiveEvent(false);
                ActiveSlots(true);
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

    private void ActiveEvent(bool isActive)
    {
        EventStory.SetActive(isActive);
        SelectCard.SetActive(isActive);
    }

    private void ActiveSlots(bool isActive)
    {
        Slots.SetActive(isActive);
        History.SetActive(isActive);
    }


    [SerializeField] private GameObject EventStory;
    [SerializeField] private GameObject SelectCard;

    [SerializeField] private GameObject Slots;
    [SerializeField] private GameObject History;

    [SerializeField] private Image MainBG;
    [SerializeField] private Image CardBG;
}
