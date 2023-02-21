using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICookhouseDetail : MonoBehaviour
{
    [SerializeField] private Text CompleteText;
    [SerializeField] private Text ReadyText;
    [SerializeField] private Text CookListText;

    [SerializeField] private Transform CookScrollTransform;
    [SerializeField] private GameObject CookObj;

    public void LoadDataCookList()
    {
        var CookCount = 4;

        CreateObj(CookCount);

        Initialize();

        for (int i = 0; i < CookCount; i++)
        {
            var item = CookScrollTransform.GetChild(i).GetComponent<UICookhouseItem>();

            item.Set("¾Ç¾î°í±â", 3);
            item.gameObject.SetActive(true);
        }
    }

    public void RefreshCookListText()
    {
        var cookList = new List<string>();

        for (int i = 0; i < CookScrollTransform.childCount; i++)
        {
            var item = CookScrollTransform.GetChild(i).GetComponent<UICookhouseItem>();

            if (item.IsActive)
            {
                cookList.Add(item.Name);
            }
        }

        CookListText.text = string.Join(", ", cookList);
    }

    private void CreateObj(int count)
    {
        var createCount = CookScrollTransform.childCount - count;

        if (createCount < 0)
        {
            createCount = Math.Abs(createCount);

            for (int i = 0; i < createCount; i++)
            {
                var obj = GameObject.Instantiate(CookObj, CookScrollTransform);

                obj.SetActive(false);
            }
        }
    }

    private void Initialize()
    {
        for (int i = 0; i < CookScrollTransform.childCount; i++)
        {
            var item = CookScrollTransform.GetChild(i).GetComponent<UICookhouseItem>();

            item.Initialized();
        }

        CookListText.text = string.Empty;
    }
}
