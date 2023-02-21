using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHouseDetail : MonoBehaviour
{
    [SerializeField] private Transform PeopleScrollTransform;
    [SerializeField] private GameObject PeopleObj;

    public void RefreshPeoples()
    {
        var peopleCount = 8;

        CreateObj(peopleCount);

        for (int i = 0; i < peopleCount; i++)
        {
            var people = PeopleScrollTransform.GetChild(i).GetComponent<UIHousePeople>();

            people.SetParty(i, $"¡÷πŒ {i}", "∏Ù?∑Á", onParty: false);
            people.gameObject.SetActive(true);
        }
    }

    private void CreateObj(int count)
    {
        var createCount = PeopleScrollTransform.childCount - count;

        if (createCount < 0)
        {
            createCount = Math.Abs(createCount);

            for (int i = 0; i < createCount; i++)
            {
                var obj = GameObject.Instantiate(PeopleObj, PeopleScrollTransform);

                obj.SetActive(false);
            }
        }
    }
}
