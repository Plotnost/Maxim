using System.Net;

namespace MaximWeb.Models;

public class RandomDel
{
    private  string _inputStr;

    public RandomDel(string inputStr)
    {
        _inputStr = inputStr;
    }
    
    public string DelRandomChar()
    {
        try
        {
            var apiUrl = $"http://www.randomnumberapi.com/api/v1.0/random?min=0&max={_inputStr.Length - 1}&count=1";

            var request = WebRequest.Create(apiUrl);

            using var response = request.GetResponse();
            using var stream = response.GetResponseStream();
            using var reader = new StreamReader(stream);
            
            var jsonResponse = reader.ReadToEnd();
            var substring = jsonResponse.Substring(1, jsonResponse.Length - 3);
            var index = int.Parse(substring);
            return _inputStr.Remove(index, 1);
        }
        catch (Exception)
        {
            var random = new Random();
            var index = random.Next(0, _inputStr.Length - 1);
            return _inputStr.Remove(index, 1);
        }
    }
}