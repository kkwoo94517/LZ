using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIEventStory : MonoBehaviour
{
    public delegate void UIStoryEndFunc();

    [SerializeField] private Text TitleText;
    [SerializeField] private Text StoryText;
    public float Speed = 0.2f;
    private bool IsSkip = false;
    private bool OnTitle = false;

    public void OnClick_ActiveSkip()
    {
        IsSkip = true;
    }

    public void LoadEventStory(UIStoryEndFunc func)
    {
        // TODO : 파라미터가 아닌 데이터 여기서 불러오기
        var title = "우와아아아앙";
        var describe = "머ㅜㄴ여ㅑ무녀윰녕ㅁ너움넝\n\n\n\n\n asfdasdasd\n\nasdasdas";

        TitleText.text = title;

        StartCoroutine(Co_ShowTitle());
        StartCoroutine(Co_Typing(describe, func));
    }

    private IEnumerator Co_ShowTitle()
    {
        float progress = 0; float duration = 10f; float increment = 0.02f / duration;

        OnTitle = false;
        TitleText.color = Color.clear;
        yield return new WaitForEndOfFrame();

        while (progress < 1)
        {
            TitleText.color = Color.Lerp(Color.clear, Color.black, progress);
            progress += increment;
            yield return new WaitForEndOfFrame();
        }

        OnTitle = true;
        yield return null;
    }

    private IEnumerator Co_Typing(string message, UIStoryEndFunc func)
    {
        while (!OnTitle)
        {
            yield return new WaitForEndOfFrame();
        }

        for (int i = 0; i < message.Length; i++)
        {
            if (IsSkip)
            {
                StoryText.text = message;

                break;
            }

            StoryText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(Speed);
        }

        func?.Invoke();
    }

    public void ClearStory()
    {
        IsSkip = false;
        StoryText.text = string.Empty;
        TitleText.text = string.Empty;
    }
}
