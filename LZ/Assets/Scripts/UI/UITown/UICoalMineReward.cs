using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoalMineReward : MonoBehaviour
{
    [SerializeField] private Image Icon;

    public void Set()
    {
        Icon.enabled = true;
    }

    public void OnClick_Receive()
    {
        // TODO : æ∆¿Ã≈€ »πµÊ ∑Œ¡˜

        Icon.enabled = false;
    }
}
