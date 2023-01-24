using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBottomNavi : MonoBehaviour
{
    private bool isChageUI = false;


    /// <summary>
    /// �ð��� �����մϴ�.
    /// </summary>
    public void OnClick_NextTime()
    {
        var player = GameManager.Instance.Player;

        // ��ư ��Ÿ ����
        if (isChageUI) { return; }
        
        // ī�带 ���� �ߴ���
        if (player.DayType == DayType.Dawn &&
            !UIManager.Instance.UIAnswer.OnSelect) { return; }

        // ������ ��ü Ȯ���Ͽ�����

        isChageUI = true;


        // ���� ���� ����
        player.SetNextTime();

        // ����, ��, ���� ���� ���� UI ����
        UIManager.Instance.UIMain.ChangeUI(player.DayType, () =>  // UI�� ���� �� ���� delegate
        {
            // ����, �ð� ��� UI ����
            UIManager.Instance.UITopNavi.SetDateUI(player.DayType, player.Date);

            // �����̶�� �̺�Ʈ ����
            if (player.DayType == DayType.Dawn)
            {
                // �̺�Ʈ �ҷ�����
                UIManager.Instance.UIEventStory.LoadEventStory(() => // �� ���丮�� ���� ���� ���� delegate
                {
                    // ���丮 �亯�� ���� ��� �ҷ�����
                    UIManager.Instance.UIAnswer.LoadAnswerItems();
                });
            }
            // ���̳� ���̶�� ������ ã��
            else
            {
                UIManager.Instance.UISlot.LoadSlotItems();
            }


            isChageUI = false;
        });
    }
}
