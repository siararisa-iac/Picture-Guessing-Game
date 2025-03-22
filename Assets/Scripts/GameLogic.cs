using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic
{
    private readonly ScreenManager _gameUi;
    private readonly LevelManager _levelManager;

    public GameLogic(ScreenManager gameUi, LevelManager levelManager)
    {
        _gameUi = gameUi;
        _levelManager = levelManager;
    }

    public void LoadNewLevel(GameLevelData data)
    {
        _gameUi.LoadNewLevel(data);
    }
}
