using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptionController : MonoBehaviour
{
    [SerializeField] private CaptionKey _captionKeyPrefab;
    [SerializeField] private RectTransform _captionContainer;

   //Big Ben
    //Big = word[0], "B", "i", "g"
    //Ben = word[1], "B", "e", "n"
    private readonly List<List<CaptionKey>> _keysByWordIndex = new();

  

    // Assume our caption is "Big Ben"
    public void Initialize(List<string> wordList)
    {
        // Clean up any reference from an old level
        foreach(var word in _keysByWordIndex){
            foreach(var key in word){
                Destroy(key.gameObject);
            }
        }
        _keysByWordIndex.Clear();

        //Instantiate the correct number of caption keys based on the word list provided
        // Iterate through the word count
        for(int wordIndex = 0; wordIndex < wordList.Count; wordIndex++)
        {
            // Add a new list for every word
            _keysByWordIndex.Add(new());
            // store the current word
            var word = wordList[wordIndex];
            // Iterate through the letters of the current word
            for(int letterIndex = 0; letterIndex < wordList[wordIndex].Length; letterIndex++)
            {
                var newCaptionKey = Instantiate(_captionKeyPrefab, _captionContainer);
                // Initialize the caption key
                // Create the keyData
                var keyData = new KeyData
                {
                    PositionData = new KeyPositionData()
                    {
                        WordIndex = wordIndex,
                        KeyIndex = letterIndex    
                    },
                    Key = word[letterIndex].ToString()
                };
                newCaptionKey.Initialize(keyData);
                newCaptionKey.OnClicked += HandleCaptionKeyClicked;
                _keysByWordIndex[wordIndex].Add(newCaptionKey);
            }
        }
    }

    private void HandleCaptionKeyClicked(KeyData data)
    {
        Debug.LogWarning($"Clicked [{data.PositionData.WordIndex}][{data.PositionData.KeyIndex}]: {data.Key}");
    }

    public void SetSpecificKeyText(KeyPositionData positionData, string text){
        // Safe checks
        if(_keysByWordIndex.Count <= positionData.WordIndex){
            Debug.LogError("Invalid word index");
            return;
        }
        if(_keysByWordIndex[positionData.WordIndex].Count <= positionData.KeyIndex){
            Debug.LogError("Invalid letter index");
            return;
        }
        var key = _keysByWordIndex[positionData.WordIndex][positionData.KeyIndex];
        key.SetLetterText(text.ToUpper());
    }
}
