using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIEventStory : MonoBehaviour
{
    public delegate void UIStoryEndFunc();

    [SerializeField] private Text StoryText;
    
    public float Speed = 0.2f;

    private bool TextEnd = false;
    private bool IsSkip = false;
    private int CurrentOrder = 0;
    private List<ScenarioEntity> ScenarioDatas;
    public bool LastScenario => ScenarioDatas.Max(e => e.Order) == CurrentOrder;

    public void OnClick_ActiveSkip()
    {
        IsSkip = true;
        TextEnd = true;
    }

    public void LoadEventStory()
    {
        var scenario = GameManager.Instance.Player.Scenario;

        if (!Database.Instance.ScenarioDict.TryGetValue(scenario.GroupId, out ScenarioDatas))
        {
            throw new System.Exception();
        }
    }

    public void ShowEventStory()
    {
        ShowEventStory(() =>
        {
            var scenario = ScenarioDatas.FirstOrDefault(e => e.Order == CurrentOrder);

            UIManager.Instance.UIAnswer.LoadAnswerItems(scenario.Answer_1, scenario.Answer_2, scenario.Answer_3);
        });
    }

    private void ShowEventStory(UIStoryEndFunc func)
    {
        CurrentOrder++;
        var scenario = ScenarioDatas.FirstOrDefault(e => e.Order == CurrentOrder);

        StartCoroutine(Co_Typing(scenario.Describe, func));
    }

    public void OnClick_GoNextStory()
    {
        if (!TextEnd) { return; }
        if (UIManager.Instance.IsChangeUI) { return; }

        if (LastScenario)
        {
            if (!UIManager.Instance.UIAnswer.OnSelect) { return; }

            UIManager.Instance.OnClick_NextTime();
            GameManager.Instance.Player.Scenario.GroupId++;
        }
        else
        {
            ClearStory();
            ShowEventStory();
        }
    }

    private IEnumerator Co_Typing(string message, UIStoryEndFunc func)
    {
        yield return new WaitForEndOfFrame();

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

        TextEnd = true;
        func?.Invoke();
    }

    public void ClearStory()
    {
        IsSkip = false;
        TextEnd = false;
        StoryText.text = string.Empty;
    }
}
