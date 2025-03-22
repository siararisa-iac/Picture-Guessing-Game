using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<ImageLevelData> _levels;

    // Temporarily putting this reference here
    [SerializeField] private ScreenManager _gameUi;

    private GameLevelData _currentLevel;
    private GameLogic _gameLogic;
    private int _currentLevelIndex = 0;

    public GameLevelData CurrentGameLevel => _currentLevel;


    private void Start()
    {
        // Setup the current level information
        LoadNewLevel();
        // Setup the game logic
       _gameLogic = new(_gameUi, this);
       _gameLogic.LoadNewLevel(CurrentGameLevel);
    }

    public void LoadNewLevel()
    {
       var currentLevelData = _levels[_currentLevelIndex];
       // Build the current level by passing the constructor
       _currentLevel = new GameLevelData(currentLevelData);
    }

    public void MoveToNextLevel()
    {
        _currentLevelIndex++;
        LoadNewLevel();
    }
}
