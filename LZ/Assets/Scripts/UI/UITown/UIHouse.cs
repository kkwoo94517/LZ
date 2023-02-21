using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHouse : UIResearchHouse
{
    public override HouseType HouseType => HouseType.House;

    [SerializeField] public UIHouseDetail UIDetail;

    private void Start()
    {
        StartCoroutine(__TEMP());
    }

    public IEnumerator __TEMP()
    {
        yield return new WaitForSeconds(1);

        int temp = 0;

        for (int i = 0; i < 8; i++)
        {
            GameManager.Instance.Player.Town.House.Peoples.Add(new People()
            {
                UniqueId = temp++,
                OnParty = false,
                Name = $"temp {temp}",
            });
        }
    }

    public void OnClick_Detail()
    {
        base.OnClick_Detail("°ÅÁÖÁö");

        UIDetail.gameObject.SetActive(true);

        UIDetail.RefreshPeoples();
    }
}
