using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] public UIMain UIMain;
    [SerializeField] public UITopNavi UITopNavi;
    [SerializeField] public UIBottomNavi UIBottomNavi;
    


    [SerializeField] public UIEventStory UIEventStory;
    [SerializeField] public UIAnswer UIAnswer;

    [SerializeField] public UISlot UISlot;
    [SerializeField] public UIHistory UIHistory;
}
