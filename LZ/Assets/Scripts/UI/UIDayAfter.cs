using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDayAfter : MonoBehaviour
{
    public bool ActiveUI => BG.gameObject.activeInHierarchy;

    private delegate void Func();

    [SerializeField] private Image BG;
    [SerializeField] private Text Title;
    [SerializeField] private Text HappyText;
    [SerializeField] private Text UnHappyText;

    public void OnClick_Disable()
    {
        this.gameObject.SetActive(false);
    }

    public void Set(int day, DayType type, int happy, int unhappy)
    {
        HappyText.text = "";
        UnHappyText.text = "";

        Title.text = $"{day}일차 - {type}";

        this.gameObject.SetActive(true);

        StartCoroutine(Co_AniBG(Title, Color.white, null));
        StartCoroutine(Co_AniBG(BG, () => 
        {
            SetHappyText(happy);
            SetUnHappyText(unhappy);

            StartCoroutine(Co_AniBG(HappyText, Color.black, null));
            StartCoroutine(Co_AniBG(UnHappyText, Color.black, null));
        }));
    }

    private void SetHappyText(int amount)
    {
        HappyText.text = $"행복 {amount}";
    }

    private void SetUnHappyText(int amount)
    {
        UnHappyText.text = $"불행 {amount}";
    }

    private IEnumerator Co_AniBG(Image image, Func func)
    {
        float progress = 0; float duration = 10f; float increment = 0.02f / duration;

        image.color = Color.clear;
        image.raycastTarget = false;

        yield return new WaitForEndOfFrame();

        while (progress < 1)
        {
            image.color = Color.Lerp(Color.clear, Color.white, progress);
            progress += increment;
            yield return new WaitForEndOfFrame();
        }

        func?.Invoke();
        image.raycastTarget = true;
        yield return new WaitForEndOfFrame();
    }

    private IEnumerator Co_AniBG(Text text, Color to, Func func)
    {
        float progress = 0; float duration = 10f; float increment = 0.02f / duration;

        text.color = Color.clear;

        yield return new WaitForEndOfFrame();

        while (progress < 1)
        {
            text.color = Color.Lerp(Color.clear, to, progress);
            progress += increment;
            yield return new WaitForEndOfFrame();
        }

        func?.Invoke();

        yield return null;
    }
}
