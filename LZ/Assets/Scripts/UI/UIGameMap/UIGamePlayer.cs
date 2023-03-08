using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePlayer : MonoBehaviour
{
    private float distance = 1.75f;
    private Vector3 defaultPos = new Vector3(-3.5f, -3.5f, 0);

    public void Initialize()
    {
        transform.localPosition = defaultPos;
    }

    public void Move(DirectionType direction)
    {
        var pos = transform.localPosition;

        switch (direction)
        {
            case DirectionType.Right:
                transform.localPosition = new Vector3(pos.x + distance, pos.y, pos.z);
                break;
            case DirectionType.Left:
                transform.localPosition = new Vector3(pos.x - distance, pos.y, pos.z);
                break;
            case DirectionType.Up:
                transform.localPosition = new Vector3(pos.x, pos.y + distance, pos.z);
                break;
            case DirectionType.Down:
                transform.localPosition = new Vector3(pos.x, pos.y - distance, pos.z);
                break;
        }
    }

    public void Teleport(int x, int y)
    {
        var pos = transform.localPosition;

        float moveX = distance * x;
        float moveY = distance * y;

        transform.localPosition = new Vector3(pos.x + moveX, pos.y - moveY, pos.z);
    }
}
