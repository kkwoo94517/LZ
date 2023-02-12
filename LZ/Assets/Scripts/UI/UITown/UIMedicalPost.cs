using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMedicalPost : MonoBehaviour
{
    [SerializeField] private Text PreviewText;
    [SerializeField] private Text LevelText;

    public void OnClick_Detail()
    {
        UIManager.Instance.UITown.SetDetailTitle("진료소");
    }

    public void SetPreview(string preview, string level)
    {
        // 회복 필요, 현재 입실 n명
        PreviewText.text = preview;
        LevelText.text = level;
    }
}
