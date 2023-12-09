using System.Diagnostics;
using MaximWeb.Models;
using Microsoft.AspNetCore.Mvc;
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
    [HttpGet]
    public IActionResult StringHadle([FromQuery(Name = "Введите строку для сортировки")] string inputStr, 
    [FromQuery(Name = "Выберете тип сортировки: 1 - сортировка деревом, 2 - Быстрая сортировка")] StringProcessingOption processingOption)
    {
        var stringHandler = new StringHandler(inputStr);
        var resultString = stringHandler.Handling();

        if (resultString.StartsWith("Ошибка"))
        {
            return BadRequest(new { Error = resultString });
        }

        var charCoundter = new CharCouter(resultString);
        var resultCount = charCoundter.CountChar();

        var subString = stringHandler.SubstringSerching();

        string? sortStr;
        switch(processingOption)
        {
            case(Option1):
                var treeSort = new TreeSort(resultString);
                sortStr = treeSort.Sort();
                break;
            case(Option2):
                var quickSort = new QuickSort(resultString);
                sortStr = quickSort.QSort();
                break;
            default:
                sortStr = "Не выбран вид сортировки";
                break;
                
        }

        return Ok(new
        {
            Обработанная_Строка = resultString,
            Количество_Символов_В_Строке = resultCount,
            Самая_длинная_подстрока_которая_начинается_и_заканчивается_на_гласную_букву = subString,
            Отсортированная_Строка = sortStr,
        });
    }
}