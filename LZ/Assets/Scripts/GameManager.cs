using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public IntroController IntroController;
    public DataController DataController;
    public Player Player;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        IntroController.Load();

        // TODO : 나중에 데이터 집어 넣기
        Player = new Player();
    }
}
