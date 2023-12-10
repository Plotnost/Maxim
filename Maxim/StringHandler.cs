namespace Maxim;

public class StringHandler{
    private string? _str;
    private readonly int _length;

    public StringHandler (string? inputStr)
    {
        _str = inputStr;
        if (_str != null) _length = _str.Length;
    }

    public bool CheckString()
    {
        if (_str == null) return false;
        var invalid = false;
        const string allowedChars = "abcdefghijklmnopqrstuvwxyz";
        
        foreach (var c in _str)
        {
            if (!char.IsLetter(c) || !char.IsLower(c) || !allowedChars.Contains(c))
            {
                Console.WriteLine($"Ошибка: Символ '{c}' не является подходящим символом.");
                invalid = true;
            }
        }

        return !invalid;
    }

    public string SubstringSerching()
    {
        string vowels = "aeiouy";
        int fistVowel = -1;
        int lastVowel = -1;
        for (var i = 0; i < _str.Length; i++)
        {
            if (vowels.Contains(_str[i]))
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
            return "Самая длинная подстрока, которая начинается и заканчивается на гласную букву: " + _str.Substring(fistVowel, lastVowel - fistVowel + 1);
        }

        return "В строке нет гласных";
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
}