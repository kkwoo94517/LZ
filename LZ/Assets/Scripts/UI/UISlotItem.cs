using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlotItem : MonoBehaviour
{
    public delegate void SlotSearchFunc();

    [SerializeField] private Image Slot;
    [SerializeField] private Color SlotActiveColor;

    [SerializeField] private Image SlotItemIcon;
    private float SearchTime = 0.6f;

    private void Awake()
    {
        Slot = GetComponent<Image>();
    }

    public void SearchAndFoundItem(float waitTime, bool isActive, Sprite sprite)
    {
        StartCoroutine(Co_Search(waitTime, () => 
        {
            ActiveSlotItem(isActive, sprite);

            if (isActive)
            {
                UIManager.Instance.UIHistory.AddHistoryItem();
            }
        }));
    }


    private void ActiveSlotItem(bool isActive, Sprite sprite)
    {
        Slot.color = isActive ? SlotActiveColor : Color.black;


        SlotItemIcon.gameObject.SetActive(isActive);
        SlotItemIcon.sprite = isActive ? sprite : null;
    }

    public void ClearSlotItem()
    {
        Slot.color = SlotActiveColor;
        SlotItemIcon.gameObject.SetActive(false);
    }

    private IEnumerator Co_Search(float waitTime, SlotSearchFunc func)
    {
        SlotItemIcon.sprite = null;
        SlotItemIcon.gameObject.SetActive(false);
        SlotItemIcon.transform.localScale = new Vector3(.5f, .5f, 1.0f);
        yield return new WaitForSeconds(waitTime);

        var timer = 0.0f;
        SlotItemIcon.gameObject.SetActive(true);

        while (SearchTime > timer)
        {
            timer += Time.deltaTime;

            SlotItemIcon.transform.Rotate(0f, 0f, 1f, Space.Self);

            yield return new WaitForEndOfFrame();
        }

        func?.Invoke();
        SlotItemIcon.transform.rotation = new Quaternion(0, 0, 0, 0);
        SlotItemIcon.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        yield break;
    }
}
