using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIGameSlot : UIGameModel
{
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Sprite DefaultBG;
    [SerializeField] private List<Sprite> RandomBG;
    [SerializeField] private GameObject SearchImage;
    private List<UISlotItem> UISlots = new List<UISlotItem>();

    private List<UISlotItem> UIActiveSlotItems;
    private List<int> ItemUniqueIds;
    private bool IsInit = false;
    private bool IsSearching = false;
    private bool IsCoSearching = false;
    public Queue<(int X, int Y)> SearchQueue;

    public override void Load(int slotRow)
    {
        base.Load();

        if (!IsInit)
        {
            IsInit = true;
            for (int row = 0; row < parentTransform.childCount; row++)
            {
                var parent = parentTransform.GetChild(row);

                InitSlots(row, parent);
            }
        }

        StartCoroutine(Co_LoadSlots(slotRow));

        this.gameObject.SetActive(true);
    }

    public void SetItems(IEnumerable<int> uniqueIds)
    {
        ItemUniqueIds = uniqueIds?.ToList();

        var random = new System.Random((int)(HelperService.RandomSeed() * 1000.0f));
        var slotCount = random.Next(uniqueIds.Count() + 2, (uniqueIds.Count() + 2) * 2);

        for (int i = 0; i < UISlots.Count; i++)
        {
            if (i > slotCount)
            {
                UISlots[i].DisableSlotItem();
            }
            else
            {
                if (ItemUniqueIds.Count > i)
                {
                    UISlots[i].SetUniqueId(ItemUniqueIds[i]);
                }
            }
        }
    }

    public void Search()
    {
        if (IsCoSearching) { return; }

        IsCoSearching = true;
        StartCoroutine(Co_StartSearch());
    }

    private IEnumerator Co_StartSearch()
    {
        while (SearchQueue.Any())
        {
            if (IsSearching)
            {
                yield return new WaitForEndOfFrame();
            }

            IsSearching = true;

            if (!SearchQueue.TryPeek(out var slot))
            {
                IsSearching = false;
                yield break;
            }

            var found = UISlots.FirstOrDefault(e => e.X == slot.X && e.Y == slot.Y);
            if (found != null)
            {
                SearchImage.transform.SetParent(found.transform, false);
                SearchImage.SetActive(true);

                StartCoroutine(Co_RotateSearch(found));
            }
            else
            {
                IsSearching = false;
                yield break;
            }
        }

        IsCoSearching = false;
    }

    private IEnumerator Co_LoadSlots(int row)
    {
        ActiveSlot(row);
        RandomSpriteSlot();
        yield return new WaitForEndOfFrame();
        LoadSlotItemsAni();
    }

    private void ActiveSlot(int row)
    {
        UIActiveSlotItems = new List<UISlotItem>();

        foreach (var slot in UISlots)
        {
            slot.ActiveSlot(slot.Y <= row && slot.X <= row);
        }

        for (int i = 0; i < parentTransform.childCount; i++)
        {
            var parent = parentTransform.GetChild(i);

            if (!parent.GetChild(0).gameObject.activeSelf)
            {
                parent.gameObject.SetActive(false);
            }
        }

        foreach (var slot in UISlots)
        {
            if (slot.gameObject.activeInHierarchy)
            {
                UIActiveSlotItems.Add(slot);
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
        foreach (var uiSlot in UISlots)
        {
            uiSlot.ClearSlotItem();
        }
    }

    private void InitSlots(int row, Transform transform)
    {
        for (int col = 0; col < transform.childCount; col++)
        {
            var child = transform.GetChild(col).GetComponent<UISlotItem>();

            child.Init(row + 1, col + 1);
            
            UISlots.Add(child);
        }
    }

    public void RandomSpriteSlot()
    {
        foreach (var uISlotItem in UIActiveSlotItems)
        {
            var random = new System.Random((int)(HelperService.RandomSeed() * 1000.0f));

            var randomSprite = random.Next(0, 3) == 1 ? RandomBG[random.Next(RandomBG.Count)] : DefaultBG;

            uISlotItem.DrawSlot(randomSprite);
        }
    }


    private IEnumerator Co_RotateSearch(UISlotItem uISlotItem)
    {
        Quaternion startRotation = SearchImage.transform.rotation;
        float endZRot = 360f;
        float t = 0;

        while (t < 3f)
        {
            t += Time.deltaTime;
            Vector3 newEulerOffset = Vector3.forward * (endZRot * t);
            
            transform.rotation = startRotation * Quaternion.Euler(newEulerOffset);

            yield return new WaitForEndOfFrame();
        }

        uISlotItem.ActiveSlotItem();
        SearchImage.SetActive(false);
        SearchQueue.Dequeue();
        IsSearching = false;
        yield break;
    }


}
