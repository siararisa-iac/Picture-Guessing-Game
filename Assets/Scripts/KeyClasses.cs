public struct KeyPositionData
{
    //the index of the current word
    public int WordIndex;
    // index of the letter in the current word
    public int KeyIndex;
}

// For example
// "Big Ben"
//i => KeyPositionData WordIndex: 0, KeyIndex: 1, Key = "i"
//B (Ben) =>KeyPositionData WordIndex: 1, KeyIndex: 0, Key = "B"
public struct KeyData
{
    public KeyPositionData PositionData;
    public string Key;
}