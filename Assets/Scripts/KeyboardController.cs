using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    [SerializeField] private KeyboardKey _keyboardKeyPrefab;
    [SerializeField] private RectTransform _keyboardContainer;

    private List<KeyboardKey> _keys = new();
    public event Action<KeyData> OnKeyClicked;

    public void Initialize(string caption, int extraLetters = 3)
    {
        // Cleanup any past level references
        foreach(var key in _keys){
            Destroy(key.gameObject);
        }
        _keys.Clear();
        
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
            var keyData = new KeyData
                {
                    PositionData = new KeyPositionData()
                    {
                        WordIndex = -1,
                        KeyIndex = keyIndex    
                    },
                    Key = keyboardKeyStrings[keyIndex]
                };
                newKeyboardKey.Initialize(keyData);
                newKeyboardKey.OnClicked += HandleKeyClicked;
                _keys.Add(newKeyboardKey);
        }
    }

    private string GetRandomLetter()
    {
        return ((char)('A' + UnityEngine.Random.Range(0, 26))).ToString();
    }

     private void HandleKeyClicked(KeyData data)
    {
       OnKeyClicked?.Invoke(data);
    }
}
