using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISawmillReward : MonoBehaviour
{
    [SerializeField] private Image Icon;

    public void Set()
    {
        Icon.enabled = true;
    }

    public void OnClick_Receive()
    {
        // TODO : ������ ȹ�� ����

        Icon.enabled = false;
    }
}
