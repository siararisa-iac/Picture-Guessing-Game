using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic
{
    private readonly ScreenManager _gameUi;
    private readonly LevelManager _levelManager;

    private GuessLogic _guessLogic;
    private int _currentWordIndex;

    public GameLogic(ScreenManager gameUi, LevelManager levelManager)
    {
        _gameUi = gameUi;
        _levelManager = levelManager;
        _guessLogic = new();

        _gameUi.KeyboardController.OnKeyClicked += HandleKeyboardClicked;
    }

    public void LoadNewLevel(GameLevelData data)
    {
        _currentWordIndex = 0;
        _gameUi.LoadNewLevel(data);
        _guessLogic.LoadNewLevel(data);
    }

    private void HandleKeyboardClicked(KeyData data){
        // logic part
        // Check the earliest available letter in the current word index
        int? availableLetterIndex = _guessLogic.GetFirstUnsolvedKeyInWordIndex(_currentWordIndex);
        if(!availableLetterIndex.HasValue){
            return;
        }

        var guessData = _guessLogic.GetGuessData(_currentWordIndex, availableLetterIndex.Value);
        // Assign the keyboard position to the guess data
        guessData.KeyboardPosition = data.PositionData;
        // Set the guessed key to the guess data
        guessData.GuessedKey = data.Key;

        // display part
        // Set the letter of the caption based on the selected keyboard key
        _gameUi.CaptionController.SetSpecificKeyText(guessData.CaptionKeyPosition, data.Key);

        // Check whether the letter guesses match the word length
        if(_guessLogic.IsWordGuessComplete(_currentWordIndex)){
            Debug.Log("Process guess");
            ProcessWordGuess(_currentWordIndex, GetCurrentWordGuess());
        }
    }

    private string GetCurrentWordGuess(){
       return _guessLogic.GetWordByIndex(_currentWordIndex);
    }

    // The actual correct or wrong logic
    private void ProcessWordGuess(int wordIndex, string guessedWord){
        var wordList = _levelManager.CurrentGameLevel.WordList;
        var word = wordList[wordIndex];
        if(word.ToLower() == guessedWord.ToLower()){
            _guessLogic.AddSolvedWordIndex(wordIndex);
            HandleCorrectGuess();
            if(_guessLogic.AreAllWordsSolvedCorrectly(wordList)){
                //Proceed to next level
                _levelManager.MoveToNextLevel();
            }
        }
        else{
            HandleIncorrectGuess();
        }
    }

    private void HandleCorrectGuess(){
        Debug.Log("Correct guesss");
    }

    private void HandleIncorrectGuess(){
        Debug.Log("Incorrect guess");
    }
}
