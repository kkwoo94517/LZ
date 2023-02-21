using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISawmillDetail : MonoBehaviour
{
    [SerializeField] private Transform RewardsScrollTransform;
    [SerializeField] private GameObject RewardsObj;

    [SerializeField] private Text AmountText;

    public void LoadDataRewards()
    {
        var rewardsCount = 4;

        CreateObj(rewardsCount);

        for (int i = 0; i < rewardsCount; i++)
        {
            var reward = RewardsScrollTransform.GetChild(i).GetComponent<UISawmillReward>();

            reward.Set();
            reward.gameObject.SetActive(true);
        }

        SetAmountText(rewardsCount);
    }

    private void SetAmountText(int count)
    {
        AmountText.text = $"오늘 생산량 : {count}개";
    }

    private void CreateObj(int count)
    {
        var createCount = RewardsScrollTransform.childCount - count;

        if (createCount < 0)
        {
            createCount = Math.Abs(createCount);

            for (int i = 0; i < createCount; i++)
            {
                var obj = GameObject.Instantiate(RewardsObj, RewardsScrollTransform);

                obj.SetActive(false);
            }
        }
    }
}
