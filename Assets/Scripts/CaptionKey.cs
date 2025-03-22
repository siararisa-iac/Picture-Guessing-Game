using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptionKey : KeyBase
{
    protected override void AwakeInternal()
    {
        SetTheme(KeyTheme.Default);
        SetLetterText(string.Empty);
    }

    public void SetLetterText(string letterText)
    {
        _letterText.text = letterText;
    }
}
