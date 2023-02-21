using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMedicalPostDetail : MonoBehaviour
{
    // 약초 uniqueId
    private int __Herb = 1;
    
    [SerializeField] private Button RecoverButton;
    [SerializeField] private Text NPCChatText;
    [SerializeField] private Text PeopleCountText;
    [SerializeField] private Transform PeopleScrollTransform;
    [SerializeField] private GameObject PeopleObj;

    public void RefreshRecoverButton()
    {
        RecoverButton.interactable = GameManager.Instance.Player.Inventory.Many(__Herb);
    }

    public void OnClick_Recover()
    {
        GameManager.Instance.Player.Inventory.Reduce(__Herb, 1);

        GameManager.Instance.Player.RecoveryHP(2);

        UIManager.Instance.UICharacterStatus.Refresh();
    }

    public void NPCChat()
    {

    }

    public void RefreshMedicalPeople()
    {
        Refresh();

        // TODO : 아픈 사람 목록
        var peopleCount = 3;

        var createCount = PeopleScrollTransform.childCount - peopleCount;

        if (createCount < 0)
        {
            createCount = Math.Abs(createCount);

            for (int i = 0; i < createCount; i++)
            {
                var obj = GameObject.Instantiate(PeopleObj, PeopleScrollTransform);

                obj.SetActive(false);
            }
        }

        for (int i = 0; i < peopleCount; i++)
        {
            var people = PeopleScrollTransform.GetChild(i).GetComponent<UIMedicalPeople>();

            people.SetMedicalPeople($"주민 {i}", "몰?루", i + 1);
            people.gameObject.SetActive(true);
        }

        SetPeopleCountText(peopleCount);
    }

    private void Refresh()
    {
        for (int i = 0; i < PeopleScrollTransform.childCount; i++)
        {
            var obj = PeopleScrollTransform.GetChild(i).gameObject;

            obj.SetActive(false);
        }
    }

    private void SetPeopleCountText(int count)
    {
        PeopleCountText.text = $"병실 인원 : {count}";
    }
}
