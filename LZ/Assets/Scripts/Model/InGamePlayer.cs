using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class InGamePlayer
{
    public int X { get; set; }
    public int Y { get; set; }

    public void Initialize(int x, int y)
    {
        X = x; Y = y;
    }

    public void Move(int x, int y)
    {
        X = x; Y = y;
    }

    public bool IsNear(int x, int y, out DirectionType direction)
    {
        direction = DirectionType.None;

        if (X == x && Y == y)
        {
            direction = DirectionType.None;
        }
        else if (X == x && Y < y + 1)
        {
            direction = DirectionType.Up;
        }
        else if (X == x && Y > y - 1)
        {
            direction = DirectionType.Down;
        }
        else if (X < x + 1 && Y == y)
        {
            direction = DirectionType.Right;
        }
        else if (X > x - 1 && Y == y)
        {
            direction = DirectionType.Left;
        }
        else
        {
            return false;
        }

        return true;
    }
}
