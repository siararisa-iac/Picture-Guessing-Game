using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class that will hold any information of the player's guesses
// Where "guess" is represented as every letter the player will input
public class GuessData
{
    // Represents the current value of the player's guess
    public string GuessedKey = string.Empty;
    // Represents the actual value of the correct letter
    public string CorrectKey {get; private set;} = string.Empty;
    // Holds the information where the key is placed in the caption
    public KeyPositionData CaptionKeyPosition;
    // Added a ? to make the KeyboardPosition nullable
    public KeyPositionData? KeyboardPosition;
    public GuessData(string correctKey, KeyPositionData captionKeyPosition)
    {
        CorrectKey = correctKey;
        CaptionKeyPosition = captionKeyPosition;
    }

    // Used when we want to remove a guess from the caption
    public void ClearGuessInput(){
        GuessedKey = string.Empty;
        KeyboardPosition = null;
    }
}
