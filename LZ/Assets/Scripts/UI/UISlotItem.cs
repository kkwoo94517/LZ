using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UISlotItem : MonoBehaviour
{
    public delegate void SlotFoundFunc();

    [SerializeField] private Image SlotImage;
    [SerializeField] private Color SlotActiveColor;

    [SerializeField] private Image SlotItemIcon;
    [SerializeField] private Button SlotButton;

    private SlotItem SlotItem;
    public int X => SlotItem.X;
    public int Y => SlotItem.Y;

    private bool isFound = false;
    private bool isSearch = false;

    public void OnClick_Search()
    {
        if (isSearch || isFound || SlotItem == null)
        {
            return;
        }

        isSearch = true;

        UIManager.Instance.UIGameMap.UIGameSlot.SearchQueue.Enqueue((X, Y));
        UIManager.Instance.UIGameMap.UIGameSlot.Search();
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

    public void SetUniqueId(int uniqueId)
    {
        SlotItem.UniqueId = uniqueId;
    }

    public void DrawSlot(Sprite sprite)
    {
        SlotImage.sprite = sprite;
    }

    public void ActiveSlot(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }

    public void ActiveSlotItem()
    {
        isFound = true;
        SlotButton.enabled = true;
        SlotImage.color = SlotActiveColor;
        SlotItemIcon.color = Color.white;
    }

    public void ClearSlotItem()
    {
        isFound = false;
        SlotImage.color = SlotActiveColor;
        SlotItemIcon.color = Color.clear;
        this.gameObject.SetActive(false);
    }

    public void DisableSlotItem()
    {
        SlotButton.enabled = false;
        this.gameObject.SetActive(true);
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
