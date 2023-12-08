namespace Maxim;
using System.Collections.Generic;

internal class CharCouter{
    private readonly string? _str;
    private Dictionary<char, int> _charCount = new Dictionary<char, int>();

    public CharCouter (string? inputStr)
    {
        _str = inputStr;
    }

    public void GetCount()
    {
        foreach (var entry in _charCount)
        {
            Console.WriteLine($"Символ '{entry.Key}' встречается {entry.Value} раз(а).");
        }
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