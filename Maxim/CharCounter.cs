namespace Maxim;
using System.Collections.Generic;

public class CharCouter{
    private readonly string? _str;
    private Dictionary<char, int> _charCount = new Dictionary<char, int>();

    public CharCouter (string? inputStr)
    {
        _str = inputStr;
    }

    public Dictionary<char, int> GetCount()
    { 
        return _charCount;
    }
    
    public void CountChar()
    {
        foreach (var c in _str)
        {
            if (_charCount.ContainsKey(c)) _charCount[c]++;
            else _charCount[c] = 1;
        }
    }

}