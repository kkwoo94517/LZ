using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    public delegate void BackGroundStartFunc();
    public delegate void BackGroundEndFunc();

    public IntroController IntroController;
    public Player Player;

    [SerializeField] private Image BackGround;

    private void Awake()
    {
        BackGround.raycastTarget = true;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        // Game, User Data Load
        IntroController.Load();
        BackGround.raycastTarget = false;
    }

    public void NewGame()
    {
        GameDataLoad();

        Player.Town.Initialize();
        InGameManager.Instance.Initialize();
        UIManager.Instance.UICharacterStatus.Refresh();
        UIManager.Instance.UIBottomNavi.OnClick_NextTime();
    }

    public void ContinueGame()
    {

    }

    public void BackGround_FadeIn(BackGroundStartFunc startFunc, BackGroundEndFunc func, float duration = 10f)
    {
        StartCoroutine(Co_BackGround_FadeIn(startFunc, func, duration));
    }

    private IEnumerator Co_BackGround_FadeIn(BackGroundStartFunc startFunc, BackGroundEndFunc endFunc, float duration)
    {
        float progress = 0; float increment = 0.02f / duration;
        BackGround.raycastTarget = true;

        yield return new WaitForEndOfFrame();
        startFunc?.Invoke();

        while (progress < 1)
        {
            BackGround.color = Color.Lerp(Color.clear, Color.black, progress);
            progress += increment;
            yield return new WaitForEndOfFrame();
        }

        BackGround.raycastTarget = false;
        BackGround.color = Color.clear;

        endFunc?.Invoke();

        yield return new WaitForEndOfFrame();
    }

    private void GameDataLoad(int uniqueId = 1, int level = 1)
    {
        if (!Database.Instance.CharacterStatusDict.TryGetValue(uniqueId, out var statusEntity))
        {
            return;
        }

        if (!Database.Instance.CharacterLevelDict.TryGetValue(level, out var levelEntities))
        {
            return;
        }

        var levelEntity = levelEntities.FirstOrDefault(e => e.Level == level);

        Player = new Player(statusEntity, levelEntity);
    }
}
