using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptionController : MonoBehaviour
{
    [SerializeField] private CaptionKey _captionKeyPrefab;
    [SerializeField] private RectTransform _captionContainer;

    // Assume our caption is "Big Ben"
    public void Initialize(List<string> wordList)
    {
        //Instantiate the correct number of caption keys based on the word list provided
        // Iterate through the word count
        for(int wordIndex = 0; wordIndex < wordList.Count; wordIndex++)
        {
           // Iterate through the letters of the current word
            for(int letterIndex = 0; letterIndex < wordList[wordIndex].Length; letterIndex++)
            {
                var newCaptionKey = Instantiate(_captionKeyPrefab, _captionContainer);
            }
        }
    }
}
