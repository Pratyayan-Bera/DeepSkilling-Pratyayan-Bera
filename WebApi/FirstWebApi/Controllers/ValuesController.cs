using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("GET Action Executed");
    }

    [HttpPost]
    public IActionResult Post()
    {
        return Ok("POST Action Executed");
    }

    [HttpPut]
    public IActionResult Put()
    {
        return Ok("PUT Action Executed");
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok("DELETE Action Executed");
    }
}