using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMedicalPostDetail : MonoBehaviour
{
    // 약초 uniqueId
    private int __Herb = 1;

    [SerializeField] private Button RecoverButton;

    public void RefreshRecoverButton()
    {
        RecoverButton.interactable = GameManager.Instance.Player.Inventory.Many(__Herb);
    }

    public void OnClick_Recover()
    {
        GameManager.Instance.Player.Inventory.Reduce(__Herb, 1);

        GameManager.Instance.Player.RecoveryHP(2);

        UIManager.Instance.UICharacterStatus.RefreshHP();
    }


}
