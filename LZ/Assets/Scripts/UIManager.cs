using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    private bool isChangeUI = false;
    public bool IsChangeUI => isChangeUI;

    [SerializeField] public UIMain UIMain;
    [SerializeField] public UITopNavi UITopNavi;
    [SerializeField] public UIDayAfter UIDayAfter;

    [SerializeField] public UICharacterStatus UICharacterStatus;


    [SerializeField] public UIEventStory UIEventStory;
    [SerializeField] public UIGameMap UIGameMap;
    [SerializeField] public UIAnswer UIAnswer;

    [SerializeField] public UIHistory UIHistory;
    
    [SerializeField] public UITown UITown;



    /// <summary>
    /// ?????? ??????????.
    /// </summary>
    public void OnClick_NextTime()
    {
        isChangeUI = true;

        var player = GameManager.Instance.Player;

        player.SetNextTime();

        if (player.DayType == DayType.Day)
        {
            UIDayAfter.Set(player.Date, player.DayType, 10, -10);
        }

        UIManager.Instance.UIMain.ChangeUI(player.DayType, () => 
        {
            UIManager.Instance.UITopNavi.SetDateUI(player.DayType, player.Date);

            isChangeUI = false;
        });
    }
}
