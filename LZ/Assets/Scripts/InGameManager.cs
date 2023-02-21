using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : Singleton<InGameManager>
{
    public InGamePlayer Player { get; private set; }

    public void Initialize()
    {
        Player = new InGamePlayer();
    }
}
