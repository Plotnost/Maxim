using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;

namespace MaximWeb.Models;

internal class StringHandler{
    private string? _str;
    private readonly int _length;

    public StringHandler (string? inputStr)
    {
        _str = inputStr;
        if (_str != null) _length = _str.Length;
    }

    public string? CheckString()
    {
        if (_str == null) return "Введите строку";
        const string allowedChars = "abcdefghijklmnopqrstuvwxyz";
        StringBuilder unvaildChars = new StringBuilder();
        var valid = true;
        
        foreach (var c in _str)
        {
            if (!char.IsLetter(c) || !char.IsLower(c) || !allowedChars.Contains(c))
            {
                unvaildChars.Append(c);
                valid = false;
            }
        }

        if (!valid)
        {
            return $"Ошибка: Символы '{unvaildChars}' не является подходящим символом.";
        }

        return this.Handling();
    }
    
    public string? Handling()
    {
        if (_length % 2 == 0)
        {
            var charStr1 = new char[_length / 2];
            var charStr2 = new char[_length / 2];
            
            for (var i = 0 ; i <_length/2; i++)
            {
                charStr1[_length/2-i-1] = _str[i];
                charStr2[i] = _str[_length-i-1];
            }

            _str = new string(charStr1) + new string(charStr2);

            return _str;
        }
        
        var charStr = _str.ToCharArray();
        Array.Reverse(charStr);
        _str = new string(charStr) + _str;
        return _str;                                                                           

    }
    
    static string SubstringSerching(string inputStr)
    {
        string vowels = "aeiouy";
        int fistVowel = -1;
        int lastVowel = -1;
        for (var i = 0; i < inputStr.Length; i++)
        {
            if (vowels.Contains(inputStr[i]))
            {
                if (fistVowel == -1)
                {
                    fistVowel = i;
                }
                lastVowel = i;
            }
        }
        if (fistVowel != -1)
        {
            return "Самая длинная подстрока, которая начинается и заканчивается на гласную букву: " + inputStr.Substring(fistVowel, lastVowel - fistVowel + 1);
        }

        return "В строке нет глассных";
    }
}

