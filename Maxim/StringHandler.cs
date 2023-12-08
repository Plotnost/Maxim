namespace Maxim;

internal class StringHandler{
    private string? _str;
    private readonly int _length;

    public StringHandler (string? inputStr)
    {
        _str = inputStr;
        if (_str != null) _length = _str.Length;
    }

    public string? Handling()
    {
        if (_str == null) return null;
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