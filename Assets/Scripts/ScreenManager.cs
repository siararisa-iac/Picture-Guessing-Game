using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private Image _levelImage;
    [SerializeField] private TextMeshProUGUI _categoryText;
    [SerializeField] private CaptionController _captionController;
    [SerializeField] private KeyboardController _keyboardController;
    
    public KeyboardController KeyboardController => _keyboardController;
    public CaptionController CaptionController => _captionController;

    public void LoadNewLevel(GameLevelData data)
    {
        _categoryText.text = data.Category;
        _levelImage.sprite = data.Image;

        _captionController.Initialize(data.WordList);
        _keyboardController.Initialize(data.Caption);
    }
}
