using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStockpilesDetail : MonoBehaviour
{
    [SerializeField] private Transform InventoryScrollTransform;
    [SerializeField] private GameObject InventoryRowObj;

    private int colLength = 7;

    public void RefreshInventoryItems()
    {
        Refresh();

        // TODO : 아이템 목록
        var peopleCount = 50;

        var createCount = (InventoryScrollTransform.childCount * colLength) - peopleCount;

        if (createCount < 0)
        {
            createCount = Math.Abs(createCount) % colLength;

            for (int i = 0; i < createCount; i++)
            {
                var obj = GameObject.Instantiate(InventoryRowObj, InventoryScrollTransform);

                obj.SetActive(false);
            }
        }

        var index = 0;
        var rowCount = peopleCount / colLength;
        var lastColCount = peopleCount % colLength;
        for (int row = 0; row <= rowCount; row++)
        {
            var rowList = InventoryScrollTransform.GetChild(row);

            for (int col = 0; col < colLength; col++)
            {
                var inventory = rowList.GetChild(col).GetComponent<UIInventoryItem>();

                inventory.gameObject.SetActive(true);

                if (rowCount == row && col >= lastColCount)
                {
                    inventory.ActiveItem(false);
                    continue;
                }


                inventory.SetSlotIndex(index++);
                inventory.SetCountText(col);
                inventory.ActiveItem(true);

                inventory.DeactiveWeight();
            }

            rowList.gameObject.SetActive(true);
        }
    }

    private void Refresh()
    {
        for (int i = 0; i < InventoryScrollTransform.childCount; i++)
        {
            var row = InventoryScrollTransform.GetChild(i);

            for (int j = 0; j < row.childCount; j++)
            {
                var item = row.GetChild(j);

                item.gameObject.SetActive(false);
            }

            row.gameObject.SetActive(false);
        }
    }
}
