using Microsoft.AspNetCore.Mvc;
using MaximWeb.Models;

[ApiController]
[Route("api/[controller]")]
public class StringHandlerController : ControllerBase
{
    [HttpGet]
    public IActionResult CheckString([FromQuery] string inputStr)
    {
        var stringHandler = new StringHandler(inputStr);
        var result = stringHandler.CheckString();

        if (result.StartsWith("Ошибка"))
        {
            return BadRequest(new { Error = result });
        }
        
        

        return Ok(new { ProcessedString = result });
    }
}