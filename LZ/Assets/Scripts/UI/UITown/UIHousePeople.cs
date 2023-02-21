using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIHousePeople : MonoBehaviour
{
    public int UniqueId;

    [SerializeField] private Text Name;
    [SerializeField] private Text Property;
    [SerializeField] private Text PartyActive;

    private Color32 ActiveColor = new Color32(144, 214, 162, 255);
    private Color32 DeActiveColor = new Color32(80, 80, 80, 255);

    public void SetParty(int uniqueId, string name, string property, bool onParty)
    {
        UniqueId = uniqueId;

        Name.text = name;
        Property.text = property;

        ActiveParty(onParty);
    }

    public void ActiveParty(bool onParty)
    {
        PartyActive.text = onParty ? "������" : "�޽���";
        PartyActive.color = onParty ? ActiveColor : DeActiveColor;
    }

    public void OnClick_OnParty()
    {
        Console.WriteLine(UniqueId);

        var peoples = GameManager.Instance.Player.Town.House.Peoples;

        var found = peoples?.FirstOrDefault(e => e.UniqueId == UniqueId);

        // ��Ƽ ����� �ƴ϶�� �߰� �� �� ������Ѵ�.
        if (!found.OnParty)
        {
            if (CommonConst.MAX_PARTY_MEMBER <= peoples.Count)
            {
                return;
            }
        }


        found.OnParty = !found.OnParty;

        ActiveParty(found.OnParty);

        if (found.OnParty)
        {
            GameManager.Instance.Player.Party.Add(found);
        }
        else
        {
            GameManager.Instance.Player.Party.Remove(found);
        }
    }
}
