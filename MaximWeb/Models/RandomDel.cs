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
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var randomApi = config.GetValue<string>("RandomApi");
            var apiUrl = randomApi.Replace("{x}", (_inputStr.Length - 1).ToString());

            var request = WebRequest.Create(apiUrl);

            using var response = request.GetResponse();
            using var stream = response.GetResponseStream();
            using var reader = new StreamReader(stream);
            
            var jsonResponse = reader.ReadToEnd();
            var substring = jsonResponse.Substring(1, jsonResponse.Length - 3);
            var index = int.Parse(substring);
            return _inputStr.Remove(index, 1);
        }
        catch (Exception ex)
        {
            var random = new Random();
            var index = random.Next(0, _inputStr.Length - 1);
            return _inputStr.Remove(index, 1);
        }
    }
}