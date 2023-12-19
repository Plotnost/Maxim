using MaximWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using static MaximWeb.Controllers.StringProcessingOption;

namespace MaximWeb.Controllers;

public enum StringProcessingOption
{
    Option1 = 1,
    Option2 = 2,
}

[ApiController]
[Route("[controller]")]
public class StringHandlerController : ControllerBase
{
    private readonly RequestLimiter _requestLimiter;

    public StringHandlerController()
    { 
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var parallelLimit = config.GetValue<int>("Settings:ParallelLimit");
        _requestLimiter = new RequestLimiter(parallelLimit);
    }
    
    [HttpGet]
    public IActionResult StringHadle([FromQuery(Name = "Введите строку для сортировки")] string inputStr, 
    [FromQuery(Name = "Выберете тип сортировки: 1 - сортировка деревом, 2 - Быстрая сортировка")] 
            StringProcessingOption processingOption)
    {
        if (!_requestLimiter.TryStartRequest())
        {
            return StatusCode(503, "Service Unavailable");
        }
        try
        {
            var stringHandler = new StringHandler(inputStr);
            var resultString = stringHandler.Handling();

            if (resultString.StartsWith("Ошибка"))
            {
                return BadRequest(new { Error = resultString });
            }

            var charCounter = new CharCouter(resultString);
            var resultCount = charCounter.CountChar();

            var subString = stringHandler.SubstringSerching();

            string? sortStr;
            switch (processingOption)
            {
                case (Option1):
                    var treeSort = new TreeSort(resultString);
                    sortStr = treeSort.Sort();
                    break;
                case (Option2):
                    var quickSort = new QuickSort(resultString);
                    sortStr = quickSort.QSort();
                    break;
                default:
                    sortStr = "Не выбран вид сортировки";
                    break;

            }

            var randomDel = new RandomDel(resultString);
            var randomDelStr = randomDel.DelRandomChar();

            return Ok(new
            {
                Обработанная_Строка = resultString,
                Количество_Символов_В_Строке = resultCount,
                Самая_длинная_подстрока_которая_начинается_и_заканчивается_на_гласную_букву = subString,
                Отсортированная_Строка = sortStr,
                Строка_С_Удалённым_Символом = randomDelStr,
            });
        }
        finally
        {
            _requestLimiter.EndRequest();
        }
    }
}