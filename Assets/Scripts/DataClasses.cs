using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
// This class stores information only for the level
public class ImageLevelData
{
    // The actual image to be displayed 
    public Sprite imageSprite;
    // The actual word to be guessed
    public string caption;
    // A clue about the caption
    public string category;
}


// This class will store game-related data for the current level

public class GameLevelData
{
    public Sprite Image {get; private set;}
    public string Caption {get; private set;} 
    public string Category {get; private set;}

    // The caption represented as a list of string (used to support multi-word guessing)
    public List<string> WordList {get; private set;}
    public int WordCount => WordList.Count;

    public GameLevelData(ImageLevelData data)
    {
        Image = data.imageSprite;
        Caption = data.caption;
        Category = data.category;
        WordList = Caption.Split(" ").ToList();
    }
}