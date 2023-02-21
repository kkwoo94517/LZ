using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISaleShopDetail : MonoBehaviour
{
    [SerializeField] private Transform SaleItemScrollTransform;
    [SerializeField] private GameObject SaleItemObj;

    [SerializeField] private Transform OwnItemScrollTransform;
    [SerializeField] private GameObject OwnRowItemObj;

    [SerializeField] private Text PriceText;

    private int colLength = 7;

    public void OnClick_Sale()
    {

    }


    public void RefreshOwnItems()
    {
        RefreshOwnItemList();

        // TODO : 아이템 목록
        var itemCount = 24;

        CreateOwnItemListObj(itemCount);

        InitializeOwnItemListObj(itemCount);
    }



    private void RefreshOwnItemList()
    {
        for (int i = 0; i < OwnItemScrollTransform.childCount; i++)
        {
            var row = OwnItemScrollTransform.GetChild(i);

            for (int j = 0; j < row.childCount; j++)
            {
                var item = row.GetChild(j);

                item.gameObject.SetActive(false);
            }

            row.gameObject.SetActive(false);
        }
    }

    private void CreateOwnItemListObj(int count)
    {
        var createCount = (OwnItemScrollTransform.childCount * colLength) - count;

        if (createCount < 0)
        {
            createCount = Math.Abs(createCount) % colLength;

            for (int i = 0; i < createCount; i++)
            {
                var obj = GameObject.Instantiate(OwnRowItemObj, OwnItemScrollTransform);

                obj.SetActive(false);
            }
        }
    }

    private void InitializeOwnItemListObj(int count)
    {
        var rowCount = count / colLength;

        for (int row = 0; row <= rowCount; row++)
        {
            var rowList = OwnItemScrollTransform.GetChild(row);

            for (int col = 0; col < colLength; col++)
            {
                var ownItem = rowList.GetChild(col).GetComponent<UISaleShopOwnItem>();

                ownItem.gameObject.SetActive(true);

                ownItem.Initialize();
            }

            rowList.gameObject.SetActive(true);
        }
    }
}
