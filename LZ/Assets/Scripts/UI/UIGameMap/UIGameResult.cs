using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameResult : UIGameModel
{
    public override void Load()
    {
        base.Load();

        this.gameObject.SetActive(true);
    }

    public void OnClick_GoTown()
    {
        UIManager.Instance.UIGameMap.Clear();
        UIManager.Instance.OnClick_NextTime();
    }
}
