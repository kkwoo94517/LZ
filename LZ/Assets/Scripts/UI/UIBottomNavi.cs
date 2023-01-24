using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBottomNavi : MonoBehaviour
{
    private bool isChageUI = false;


    /// <summary>
    /// 시간을 변경합니다.
    /// </summary>
    public void OnClick_NextTime()
    {
        var player = GameManager.Instance.Player;

        // 버튼 연타 막기
        if (isChageUI) { return; }
        
        // 카드를 선택 했는지
        if (player.DayType == DayType.Dawn &&
            !UIManager.Instance.UIAnswer.OnSelect) { return; }

        // 슬롯을 전체 확인하였는지

        isChageUI = true;


        // 다음 날로 설정
        player.SetNextTime();

        // 새벽, 밤, 낮에 따른 메인 UI 변경
        UIManager.Instance.UIMain.ChangeUI(player.DayType, () =>  // UI가 변경 된 후의 delegate
        {
            // 일자, 시간 상단 UI 변경
            UIManager.Instance.UITopNavi.SetDateUI(player.DayType, player.Date);

            // 새벽이라면 이벤트 노출
            if (player.DayType == DayType.Dawn)
            {
                // 이벤트 불러오기
                UIManager.Instance.UIEventStory.LoadEventStory(() => // 긴 스토리가 전부 나온 후의 delegate
                {
                    // 스토리 답변에 대한 목록 불러오기
                    UIManager.Instance.UIAnswer.LoadAnswerItems();
                });
            }
            // 밤이나 낮이라면 아이템 찾기
            else
            {
                UIManager.Instance.UISlot.LoadSlotItems();
            }


            isChageUI = false;
        });
    }
}
