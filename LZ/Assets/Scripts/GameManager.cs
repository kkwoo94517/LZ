using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public IntroController IntroController;
    public DataController DataController;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        IntroController.Load();
    }
}
