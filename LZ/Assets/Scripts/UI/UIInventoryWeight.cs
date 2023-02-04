using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryWeight : MonoBehaviour
{
    [SerializeField] private Text WeightText;

    private void Awake()
    {
        WeightText.text = GetWeightText(1.1f, 10.0f);
    }

    private string GetWeightText(float current, float max)
    {
        string currentString = string.Format("{0:F1}", current);
        string maxString = string.Format("{0:F1}", max);

        return $"<color=#ffffff>{currentString}</color>/<color=#ffffff>{maxString}</color>kg";
    }
}
