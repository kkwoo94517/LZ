using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tileset : MonoBehaviour
{
    private bool IsSearch = false;
    public UIGameTileIcon UITileIcon { get; set; }

    public void Load()
    {
        IsSearch = false;

        Sprite = this.GetComponent<SpriteRenderer>();

        if (!IsFloor)
        {
            Sprite.color = FloorColor;
        }
        else if (EventType == TileEventType.Start)
        {
            Sprite.color = SearchColor;
        }
        else
        {
            Sprite.color = NotSearchColor;
        }
    }

    public void Search()
    {
        if (!IsSearch)
        {
            IsSearch = true;

            Sprite.color = SearchColor;
        }

        UIManager.Instance.UIGameMap.Active(EventType);
    }

    #region 에디터에서 설정하는 데이터들
    public bool IsFloor = false;
    public int X = 0;
    public int Y = 0;
    public TileEventType EventType = TileEventType.None;
    #endregion

    private SpriteRenderer Sprite;
    private Color SearchColor = Color.white;
    private Color32 NotSearchColor = new(130, 130, 130, 255);
    private Color32 FloorColor = new(80, 80, 80, 255);
}
