using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class InGamePlayer
{
    public int X { get; set; } = 1;
    public int Y { get; set; } = 0;

    public Stage Stage { get; set; }

    public void InitStage(int stageId)
    {
        Stage = new Stage
        {
            StageId = stageId,
        };
    }

    public bool IsNear(int x, int y)
    {
        if ((X == x || X + 1 == x || X - 1 == x) &&
            (Y == y || Y + 1 == y || Y - 1 == y))
        {
            return true;
        }

        return false;
    }
}
