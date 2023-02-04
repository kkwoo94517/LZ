using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Transform InventoryTransformParent;

    private List<GameObject> RowObjects = new List<GameObject>();
    private List<UIInventoryItem> UIInventoryItems = new List<UIInventoryItem>();

    public int ActiveItemCount => UIInventoryItems.Count;
    private int DefaultActiveItemCount => 16;
    private int DefaultActiveRowCount => 4;

    private void Awake()
    {
        int index = 1;
        for (int row = 0; row < InventoryTransformParent.childCount; row++)
        {
            var rowObject = InventoryTransformParent.GetChild(row).gameObject;

            RowObjects.Add(rowObject);

            for (int col = 0; col < rowObject.transform.childCount; col++)
            {
                var colObject = rowObject.transform.GetChild(col);
                var item = colObject.GetComponent<UIInventoryItem>();

                item.SetSlotIndex(index++);
                UIInventoryItems.Add(item);
            }
        }
    }

    private void ActiveRowObject()
    {
        var col = (DefaultActiveItemCount + ActiveItemCount) % ActiveItemCount;

        RowObjects[col].SetActive(true);
    }

    private void ClearRowObject()
    {
        RowObjects.Skip(DefaultActiveRowCount).ToList().ForEach(e => e.SetActive(false));
    }
}
