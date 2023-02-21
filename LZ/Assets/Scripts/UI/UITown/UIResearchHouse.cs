using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResearchHouse : MonoBehaviour
{
    public virtual HouseType HouseType { get; protected set; }
    public bool IsLoadDone { get; set; }

    protected virtual void OnClick_Detail(string title)
    {
        UIManager.Instance.UITown.SetDetailTitle(title);
        UIManager.Instance.UITown.TurnOffActive();
        UIManager.Instance.UITown.SetDetailIcon(IconImage.sprite);
    }

    public virtual void SetPreview(string preview, string level)
    {
        // 현재 아이템 n개
        PreviewText.text = preview;
        LevelText.text = level;

    }

    [SerializeField] private Text PreviewText;
    [SerializeField] private Text LevelText;
    [SerializeField] private Image IconImage;
}
