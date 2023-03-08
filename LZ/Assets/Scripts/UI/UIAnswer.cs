using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnswer : MonoBehaviour
{
    private int SelectIndex;
    public bool OnSelect => SelectIndex != 0;

    private bool LoadDone = false;
    private bool NeedSelect = false;

    public void LoadAnswerItems(int answer1, int answer2, int answer3)
    {
        // TODO : ������ �ε�
        SelectIndex = 0;
        NeedSelect = false;

        if (answer1 != 0)
        {
            // Load Answer
            NeedSelect = true;
            UIAnswerItem_1.SetAnswerText("������", "����̤���̤�", "�ǰ���", true);
        }
        if (answer2 != 0)
        {
            NeedSelect = true;
            UIAnswerItem_2.SetAnswerText("123", "���ô�����������", "", true);
        }
        if (answer3 != 0)
        {
            NeedSelect = true;
            UIAnswerItem_3.SetAnswerText("5857857", "", "�Ƹ���", false);
        }

        LoadDone = true;
    }

    public void ClearAnswerItems()
    {
        SelectIndex = 0;

        UIAnswerItem_1.DisableAnswerItem();
        UIAnswerItem_2.DisableAnswerItem();
        UIAnswerItem_3.DisableAnswerItem();

        LoadDone = false;
    }

    public void OnClick_Answer(int index)
    {
        if (UIManager.Instance.IsChangeUI)
        {
            return;
        }

        if (!LoadDone)
        {
            return;
        }

        if (!NeedSelect)
        {
            return;
        }

        SelectIndex = index;

        UIAnswerItem_1.SelectItem(index);
        UIAnswerItem_2.SelectItem(index);
        UIAnswerItem_3.SelectItem(index);
    }

    [SerializeField] private UIAnswerItem UIAnswerItem_1;
    [SerializeField] private UIAnswerItem UIAnswerItem_2;
    [SerializeField] private UIAnswerItem UIAnswerItem_3;
}
