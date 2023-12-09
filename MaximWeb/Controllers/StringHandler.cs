using MaximWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaximWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StringHandlerController : ControllerBase
{
    [HttpGet]
    public IActionResult StringHadle([FromQuery] string inputStr)
    {
        var stringHandler = new StringHandler(inputStr);
        var resultString = stringHandler.Handling();

        if (resultString.StartsWith("Ошибка"))
        {
            return BadRequest(new { Error = resultString });
        }

        var charCoundter = new CharCouter(resultString);
        var resultCount = charCoundter.CountChar();
        
        return Ok(new
        {
            Обработанная_Строка = resultString,
            Количество_Символов_В_Строке = resultCount
        });
    }
}