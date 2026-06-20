using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers;

[ApiController]
[Route("api/Emp")]
public class EmployeeController : ControllerBase
{
    private static List<object> employees = new()
    {
        new { Id = 1, Name = "Rahul", Salary = 25000 },
        new { Id = 2, Name = "Amit", Salary = 30000 },
        new { Id = 3, Name = "Priya", Salary = 35000 }
    };

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetEmployees()
    {
        return Ok(employees);
    }
}