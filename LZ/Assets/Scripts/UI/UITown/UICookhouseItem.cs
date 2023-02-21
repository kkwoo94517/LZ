using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICookhouseItem : MonoBehaviour
{
    [SerializeField] private GameObject SelectIcon;
    [SerializeField] private Text Title;
    [SerializeField] private Text Amount;

    public bool IsActive { get; set; } = false;
    public string Name { get { return Title.text; } }

    public void OnClick_Active()
    {
        IsActive = !IsActive;

        Active(IsActive);

        UIManager.Instance.UITown.UICookhouse.UIDetail.RefreshCookListText();
    }

    public void Initialized()
    {
        Title.text = string.Empty;
        Amount.text = string.Empty;

        IsActive = false;
        Active(false);
    }

    public void Set(string title, int amount)
    {
        Title.text = title;
        Amount.text = amount.ToString();
    }

    public void Active(bool isActive)
    {
        SelectIcon.SetActive(isActive);
    }
}
