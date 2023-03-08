using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameMap : MonoBehaviour
{
    [SerializeField] public InGameStage InGameStage;
    [SerializeField] public UIGameEvent UIGameEvent;
    [SerializeField] public UIGameSpecialItem UIGameSpecialItem;
    [SerializeField] public UIGameMonster UIGameMonster;
    [SerializeField] public UIGameSlot UIGameSlot;
    [SerializeField] public UIGameResult UIGameResult;




    public void LoadGameMap()
    {
        var stage = GameManager.Instance.Player.Stage.StageId;

        InGameStage.LoadData(stage);
        InGameStage.ShuffleTileEvent(stage);
        InGameStage.gameObject.SetActive(true);
    }



    public void Active(TileEventType eventType)
    {
        switch (eventType)
        {
            case TileEventType.Start:
                break;
            case TileEventType.End:
                UIGameResult.Load();

                break;
            case TileEventType.Event:
                UIGameEvent.Load();

                break;
            case TileEventType.NormalItems:
                UIGameSlot.Load(4);

                break;
            case TileEventType.SpecialItem:
                UIGameSpecialItem.Load();

                break;
            case TileEventType.Monster:
                UIGameMonster.Load();

                break;
        }
    }



    public void Clear()
    {
        InGameStage.gameObject.SetActive(false);

        UIGameSlot.gameObject.SetActive(false);
        UIGameResult.gameObject.SetActive(false);
    }
}
