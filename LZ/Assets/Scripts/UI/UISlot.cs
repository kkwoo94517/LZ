using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class UISlot : MonoBehaviour
{
    private List<UISlotItem> UISlots = new List<UISlotItem>();

    private void Awake()
    {
        InitSlots(RowSlot_1);
        InitSlots(RowSlot_2);
        InitSlots(RowSlot_3);
        InitSlots(RowSlot_4);
    }

    public void LoadSlotItems()
    {
        float waitTime = 0.0f;

        foreach (var slot in UISlots)
        {
            waitTime += 0.6f;

            slot.SearchAndFoundItem(waitTime, true, null);
        }
    }

    public void ClearSlotItems()
    {
        UISlots.ForEach(e => e.ClearSlotItem());
    }

    private void InitSlots(Transform transform)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).GetComponent<UISlotItem>();

            UISlots.Add(child);
        }
    }

    [SerializeField] private Transform RowSlot_1;
    [SerializeField] private Transform RowSlot_2;
    [SerializeField] private Transform RowSlot_3;
    [SerializeField] private Transform RowSlot_4;
}
