using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum KeyTheme
{
    Default,
    Correct,
    Wrong
}

public class KeyBase : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _letterText;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _defaultTheme;
    [SerializeField] private GameObject _correctTheme;
    [SerializeField] private GameObject _wrongTheme;

    private Dictionary<KeyTheme, GameObject> _themeBackgrounds;

    public void Initialize(string letter)
    {
        _letterText.text = letter;
    }
    
    protected virtual void Awake()
    {
        // Map out the matching gameobject to the corresponding theme enum
        _themeBackgrounds = new()
        {
            {KeyTheme.Default, _defaultTheme},
            {KeyTheme.Correct, _correctTheme},
            {KeyTheme.Wrong, _wrongTheme}
        };
        _button.onClick.AddListener(OnButtonClicked);
        AwakeInternal();
    }
    public void SetTheme(KeyTheme theme)
    {
        // Type safe
        if(!_themeBackgrounds.ContainsKey(theme))
        {
            Debug.LogError($"Theme {theme} is not defined");
        }
        // Iterating through each enum and enabling/disable the gameobject based on 
        // the given theme
        foreach(var themeKey in _themeBackgrounds.Keys)
        {
            _themeBackgrounds[themeKey].SetActive(themeKey == theme);
        }
    }

    protected virtual void AwakeInternal(){}
    private void OnButtonClicked()
    {
        OnButtonClickedInternal();
    }

    protected virtual void OnButtonClickedInternal(){}
}
