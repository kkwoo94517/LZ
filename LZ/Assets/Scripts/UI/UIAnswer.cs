using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnswer : MonoBehaviour
{
    private int SelectIndex;
    public bool OnSelect => SelectIndex != 0;


    public void LoadAnswerItems()
    {
        // TODO : ������ �ε�
        SelectIndex = 0;

        UIAnswerItem_1.SetAnswerText("������", "����̤���̤�", "�ǰ���", true);
        UIAnswerItem_2.SetAnswerText("123", "���ô�����������", "", true);
        UIAnswerItem_3.SetAnswerText("5857857", "", "�Ƹ���", false);
    }

    public void ClearAnswerItems()
    {
        SelectIndex = 0;

        UIAnswerItem_1.DisableAnswerItem();
        UIAnswerItem_2.DisableAnswerItem();
        UIAnswerItem_3.DisableAnswerItem();
    }

    public void OnClick_Answer(int index)
    {
        SelectIndex = index;

        UIAnswerItem_1.SelectItem(index);
        UIAnswerItem_2.SelectItem(index);
        UIAnswerItem_3.SelectItem(index);
    }

    [SerializeField] private UIAnswerItem UIAnswerItem_1;
    [SerializeField] private UIAnswerItem UIAnswerItem_2;
    [SerializeField] private UIAnswerItem UIAnswerItem_3;
}
