using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will handle the guessing logic -
// is the letter at the correct place? is the word completed?
public class GuessLogic
{
    // Guess Data per letter per word
    private List<List<GuessData>> _captionGuesses = new();
    // Store the index of any word that is solved
    private List<int> _solvedWordIndices = new();

    public void LoadNewLevel(GameLevelData levelData){
        _captionGuesses.Clear();
        _solvedWordIndices.Clear();
        // Fill up the caption guesses
        for(int wordIndex = 0; wordIndex < levelData.WordCount; wordIndex++){
            // Create a new list per word
            _captionGuesses.Add(new());
            string currentWord = levelData.WordList[wordIndex];
            Debug.LogWarning($"Current word: {currentWord}, {currentWord.Length}");
            // Iterate through each letter in the current word
            for(int letterIndex = 0; letterIndex < currentWord.Length; letterIndex++){
                // Initialize the guess data with the correct position and key
                var captionKeyPosition = new KeyPositionData(){
                    WordIndex = wordIndex,
                    KeyIndex = letterIndex
                };
                var captionKeyString = currentWord[letterIndex].ToString();
                // Fill up the list
                _captionGuesses[wordIndex].Add(new GuessData(captionKeyString, captionKeyPosition));
                Debug.LogWarning($"Letter Count: {_captionGuesses[wordIndex].Count}");
            }
        }
        Debug.LogWarning($"Count: {_captionGuesses.Count}");
    }

    public int? GetFirstUnsolvedKeyInWordIndex(int wordIndex){
        // Get the earliest empty guess string index
        for(int keyInWordIndex = 0; keyInWordIndex < _captionGuesses[wordIndex].Count; keyInWordIndex++){
            var guessData = _captionGuesses[wordIndex][keyInWordIndex];
            if(guessData.GuessedKey == string.Empty){
                return keyInWordIndex;
            }
        }
        return null;
    }
    // Get a specific guessData based on the given word and letter index
    public GuessData GetGuessData(int wordIndex, int keyInWordIndex){
        return _captionGuesses[wordIndex][keyInWordIndex];
    }

    // Return the word created through the guessed key 
    public string GetWordByIndex(int wordIndex){
        string word = string.Empty;
        for(int i = 0 ; i < _captionGuesses[wordIndex].Count; i++){
            word += _captionGuesses[wordIndex][i].GuessedKey;
        }
        return word.ToLower();
    }

    // Returns true only if every caption has a guessed key
    public bool IsWordGuessComplete(int wordIndex){
        for(int i = 0 ; i < _captionGuesses[wordIndex].Count; i++){
            if(_captionGuesses[wordIndex][i].GuessedKey == string.Empty)
            {
                return false;
            }
        }
        return true;
    }

    public void AddSolvedWordIndex(int wordIndex){
        _solvedWordIndices.Add(wordIndex);
    }

    public bool AreAllWordsSolvedCorrectly(List<string> targetWordList){
        return _solvedWordIndices.Count == targetWordList.Count;
    }
}
