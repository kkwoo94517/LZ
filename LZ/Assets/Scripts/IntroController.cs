using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    public GameObject Intro;
    public Image NextButton;

    public void Load()
    {
        NextButton.raycastTarget = false;
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForEndOfFrame();

    }

    public void Onclick_LoadDone()
    {
        Intro.SetActive(false);
    }
}
