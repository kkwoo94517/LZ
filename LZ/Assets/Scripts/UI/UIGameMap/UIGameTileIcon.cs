using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameTileIcon : MonoBehaviour
{
    private SpriteRenderer Sprite;
    private Vector3 pos = new Vector3(0.3f, 0.3f, 0);

    public void Set()
    {
        Sprite = GetComponent<SpriteRenderer>();

        this.gameObject.SetActive(false);
        this.transform.localPosition = pos;
    }

    public void Active()
    {
        Sprite.color = Color.white;

        this.gameObject.SetActive(true);
    }

    public void Near()
    {
        Sprite.color = Color.black;
    }

    public void DeActive()
    {
        Sprite.color = Color.gray;
    }
}
