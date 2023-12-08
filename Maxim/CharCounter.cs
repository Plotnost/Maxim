namespace Maxim;
using System.Collections.Generic;

internal class CharCouter{
    private readonly string? _str;
    Dictionary<char, int> charCount = new Dictionary<char, int>();

    public CharCouter (string? inputStr)
    {
        _str = inputStr;
    }

    public void GetCount()
    {
        foreach (var entry in charCount)
        {
            Console.WriteLine($"Символ '{entry.Key}' встречается {entry.Value} раз(а).");
        }
    }
    
    public void CountChar()
    {
        foreach (var c in _str)
        {
            if (charCount.ContainsKey(c)) charCount[c]++;
            else charCount[c] = 1;
        }
    }

}