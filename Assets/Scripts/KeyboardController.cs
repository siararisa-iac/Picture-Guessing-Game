using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    [SerializeField] private KeyboardKey _keyboardKeyPrefab;
    [SerializeField] private RectTransform _keyboardContainer;

    // Assume our caption is "Big Ben"
    public void Initialize(string caption, int extraLetters = 3)
    {
        var keyboardKeyStrings = new List<string>();
        // add each character of the caption to the list
        for(int i = 0; i < caption.Length; i++){
            char currentChar = caption[i];
            // For now ignore spaces
            if(currentChar == ' ')
            {
                continue;
            }
            keyboardKeyStrings.Add(currentChar.ToString());
        }
        // add extra letters
        for(int i = 0; i < extraLetters; i++){
            var random = GetRandomLetter();
            keyboardKeyStrings.Add(random);
        }
        // Shuffle the list
        keyboardKeyStrings.Shuffle();

        for(int keyIndex = 0; keyIndex < keyboardKeyStrings.Count; keyIndex++)
        {
            var newKeyboardKey = Instantiate(_keyboardKeyPrefab, _keyboardContainer);
            newKeyboardKey.Initialize(keyboardKeyStrings[keyIndex]);
        }
    }

    private string GetRandomLetter()
    {
        return ((char)('A' + Random.Range(0, 26))).ToString();
    }
}
