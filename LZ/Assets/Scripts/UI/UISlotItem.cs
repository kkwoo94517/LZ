using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;

public class UISlotItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public delegate void SlotFoundFunc();

    [SerializeField] private Image SlotImage;
    [SerializeField] private Color SlotActiveColor;

    [SerializeField] private Image SlotItemIcon;

    private SlotItem SlotItem;
    public int X => SlotItem.X;
    public int Y => SlotItem.Y;

    // TODO : 찾는 딜레이 시간
    private float SearchTime = 0.0f;
    private float SearchDelayTime = 1.0f;
    private bool isFound = false;
    private bool isSearch = false;
    private bool isFoundHalf = false;

    public void Update()
    {
        if (isFound)
        {
            return;
        }

        if (isSearch)
        {
            SearchTime += Time.deltaTime / SearchDelayTime;

            SlotImage.color = Color.Lerp(Color.white, Color.clear, SearchTime);

            if (!isFoundHalf && SlotImage.color.a <= 0.75f)
            {
                isFoundHalf = true;
                SlotItemIcon.color = Color.black;
            }

            if (SlotImage.color.a <= 0.1f)
            {
                ActiveSlotItem();
                UIManager.Instance.UIHistory.AddHistoryItem();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isFound) { return; }

        isSearch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isSearch = false;
    }

    public void LoadSlotAni(float delay)
    {
        StartCoroutine(Co_Load(delay));
    }

    public void Init(int x, int y)
    {
        SlotItem = new SlotItem
        {
            X = x,
            Y = y,
        };

    }

    public void DrawSlot(Sprite sprite)
    {
        SlotImage.sprite = sprite;
    }

    public void ActiveSlot(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }

    private void ActiveSlotItem()
    {
        isFound = true;
        SlotImage.color = SlotActiveColor;
        SlotItemIcon.color = Color.white;
    }

    public void ClearSlotItem()
    {
        isFound = false;
        isFoundHalf = false;
        SearchTime = 0.0f;
        SlotImage.color = SlotActiveColor;
        SlotItemIcon.color = Color.clear;
        this.gameObject.SetActive(false);
    }

    private IEnumerator Co_Load(float delay)
    {
        var random = new System.Random((int)DateTime.Now.Ticks);
        yield return new WaitForSeconds(delay);

        var whiteColor = new Color32((byte)random.Next(245, 255), (byte)random.Next(245, 255), (byte)random.Next(245, 255), 255);
        float progress = 0; float duration = 10f; float increment = 0.02f / duration;

        while (progress < 1)
        {
            SlotImage.color = Color.Lerp(SlotActiveColor, whiteColor, progress);
            progress += increment;
            yield return new WaitForEndOfFrame();
        }

        SlotImage.color = whiteColor;
        yield break;
    }
}
