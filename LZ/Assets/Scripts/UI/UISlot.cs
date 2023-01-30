using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Transform parentTransform;
    private Dictionary<int, List<UISlotItem>> UISlots = new Dictionary<int, List<UISlotItem>>();

    private List<UISlotItem> UIActiveSlotItems;

    private void Awake()
    {
        for (int row = 0; row < parentTransform.childCount; row++)
        {
            var parent = parentTransform.GetChild(row);

            InitSlots(row, parent);
        }
    }

    public void LoadSlotItems(int row)
    {
        StartCoroutine(Co_LoadSlots(row));
    }

    private IEnumerator Co_LoadSlots(int row)
    {
        ActiveSlot(row);
        yield return new WaitForEndOfFrame();
        LoadSlotItemsAni();
    }


    private void ActiveSlot(int row)
    {
        UIActiveSlotItems = new List<UISlotItem>();

        foreach (var slots in UISlots.Values)
        {
            foreach (var slot in slots)
            {
                slot.ActiveSlot(slot.Y <= row && slot.X <= row);
            }
        }

        for (int i = 0; i < parentTransform.childCount; i++)
        {
            var parent = parentTransform.GetChild(i);

            if (!parent.GetChild(0).gameObject.activeSelf)
            {
                parent.gameObject.SetActive(false);
            }
        }

        foreach (var slots in UISlots.Values)
        {
            foreach (var slot in slots)
            {
                if (slot.gameObject.activeInHierarchy)
                {
                    UIActiveSlotItems.Add(slot);
                }
            }
        }
    }

    private void LoadSlotItemsAni()
    {
        float waitTime = 0.0f;

        foreach (var slot in UIActiveSlotItems)
        {
            waitTime += 0.01f;

            slot.LoadSlotAni(waitTime);
        }
    }

    public void ClearSlotItems()
    {
        foreach (var uiSlot in UISlots.Values)
        {
            uiSlot.ForEach(e => e.ClearSlotItem());
        }
    }

    private void InitSlots(int row, Transform transform)
    {
        for (int col = 0; col < transform.childCount; col++)
        {
            var child = transform.GetChild(col).GetComponent<UISlotItem>();

            if (!UISlots.ContainsKey(row))
            {
                UISlots.Add(row, new List<UISlotItem>());
            }

            child.Init(row + 1, col + 1);
            UISlots[row].Add(child);
        }
    }







}
