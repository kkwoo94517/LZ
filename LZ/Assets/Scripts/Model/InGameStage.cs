using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;

public class InGameStage : MonoBehaviour
{
    [SerializeField] private UIGamePlayer UIGamePlayer;
    [SerializeField] private GameObject SubIcon;

    private List<Tileset> Tilesets = new List<Tileset>();

    private int Width = 0;
    private int Height = 0;


    public void LoadData(int stageId)
    {
        Tilesets.Clear();

        var stageObj = this.transform.GetChild(stageId - 1);

        for (int i = 0; i < stageObj.childCount; i++)
        {
            var tileset = stageObj.GetChild(i).GetComponent<Tileset>();

            tileset.Load();
            Tilesets.Add(tileset);
        }

        Width = Tilesets.Max(e => e.X) + 1;
        Height = Tilesets.Max(e => e.Y) + 1;

        stageObj.gameObject.SetActive(true);
    }

    public void ShuffleTileEvent(int stageId)
    {
        if (!Database.Instance.StageDict.TryGetValue(stageId, out var datas))
        {
            return;
        }

        var tilesetClone = new List<Tileset>(Tilesets.Where(e => e.EventType == TileEventType.None && e.IsFloor));

        foreach (var stageData in datas)
        {
            if (stageData.TileEventType == TileEventType.Start)
            {
                var startTile = Tilesets.FirstOrDefault(e => e.EventType == stageData.TileEventType);

                UIGamePlayer.Initialize();
                UIGamePlayer.Teleport(startTile.X, startTile.Y);
                InGameManager.Instance.Player.Initialize(startTile.X, startTile.Y);
            }

            if (Database.Instance.StageTileDict.TryGetValue(stageData.TileEventType, out var tileData))
            {
                var found = tileData.FirstOrDefault(e => e.Grade == stageData.Grade);
                if (found != null)
                {
                    // TODO : RandomÇÑ À§Ä¡
                    var tileset = tilesetClone.FirstOrDefault();

                    switch (stageData.TileEventType)
                    {
                        case TileEventType.Event:
                            break;
                        case TileEventType.NormalItems:
                            CreateIcon(tileset);
                            UIManager.Instance.UIGameMap.UIGameSlot.SetItems(found.UniqueList);
                            break;
                        case TileEventType.SpecialItem:
                            break;
                        case TileEventType.Monster:
                            break;
                    }

                    tilesetClone.Remove(tileset);
                }
            }
        }
    }

    private void CreateIcon(Tileset tileset)
    {
        if (tileset.UITileIcon != null) { return; }

        var obj = Instantiate(SubIcon, tileset.transform);

        tileset.UITileIcon = obj.GetComponent<UIGameTileIcon>();
        tileset.UITileIcon.Set();

    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                var tileset = hit.transform?.GetComponent<Tileset>();
                if (tileset != null)
                {
                    if (CanMove(tileset.X, tileset.Y, out var x, out var y, out var direction))
                    {
                        tileset = Tilesets?.FirstOrDefault(e => e.X == x && e.Y == y);

                        InGameManager.Instance.Player.Move(x, y);

                        UIGamePlayer.Move(direction);

                        tileset.Search();
                    }
                }
            }
        }
#else
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0);
                    hit.collider.GetComponent<MeshRenderer>().material.color = newColor;
                }
            }
        }
#endif
    }

    public bool CanMove(int tileX, int tileY, out int realX, out int realY, out DirectionType direction)
    {
        realX = tileX; realY = tileY;
        direction = DirectionType.None;
        
        if (UIManager.Instance.IsChangeUI)
        {
            return false;
        }

        if (UIManager.Instance.UIDayAfter.ActiveUI)
        {
            return false;
        }

        if (!InGameManager.Instance.Player.IsNear(tileX, tileY, out direction))
        {
            return false;
        }

        (realX, realY) = PlayerPos(direction);

        tileX = realX; tileY = realY;

        return Tilesets?.FirstOrDefault(e => e.X == tileX && e.Y == tileY).IsFloor ?? false;
    }

    public (int X, int Y) PlayerPos(DirectionType direction)
    {
        return direction switch
        {
            DirectionType.Right =>  (InGameManager.Instance.Player.X + 1, InGameManager.Instance.Player.Y),
            DirectionType.Left =>   (InGameManager.Instance.Player.X - 1, InGameManager.Instance.Player.Y),
            DirectionType.Up =>     (InGameManager.Instance.Player.X, InGameManager.Instance.Player.Y + 1),
            DirectionType.Down =>   (InGameManager.Instance.Player.X, InGameManager.Instance.Player.Y - 1),

            _ => (InGameManager.Instance.Player.X, InGameManager.Instance.Player.Y),
        };
    }
}
