using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InGameStage : MonoBehaviour
{
    private List<Tileset> Tilesets = new List<Tileset>();
    
    private int Width = 0;
    private int Height = 0;


    public void LoadData(int stageId)
    {
        Tilesets.Clear();

        int stage = 1;

        var stageObj = this.transform.GetChild(stage - 1);

        for (int i = 0; i < stageObj.childCount; i++)
        {
            var tileset = stageObj.GetChild(i).GetComponent<Tileset>();

            Tilesets.Add(tileset);
        }

        Width = Tilesets.Max(e => e.X) + 1;
        Height = Tilesets.Max(e => e.Y) + 1;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("input ");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                var tileset = hit.transform?.GetComponent<Tileset>();
                if (tileset != null)
                {
                    Debug.Log($"input {hit.point.x} {hit.point.y}");

                    if (CanMove(tileset.X, tileset.Y))
                    {
                        Debug.Log($"can move {tileset.X} {tileset.Y}");
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

    public bool CanMove(int x, int y)
    {
        if (!InGameManager.Instance.Player.IsNear(x, y))
        {
            return false;
        }

        return Tilesets?.FirstOrDefault(e => e.X == x && e.Y == y).IsFloor ?? false;
    }
}
