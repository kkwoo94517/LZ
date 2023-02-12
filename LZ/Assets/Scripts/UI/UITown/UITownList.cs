using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITownList : MonoBehaviour
{

    public void OnClick_Open()
    {
        UIManager.Instance.UITown.UIMedicalPost.SetPreview("", "");


    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
