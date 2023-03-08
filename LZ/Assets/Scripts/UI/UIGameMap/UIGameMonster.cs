using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameMonster : UIGameModel
{
    public override void Load()
    {
        base.Load();

        this.gameObject.SetActive(true);
    }
}
