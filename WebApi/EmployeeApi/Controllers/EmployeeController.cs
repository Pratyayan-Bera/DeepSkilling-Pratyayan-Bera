using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;

namespace EmployeeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EmployeeController : ControllerBase
{
    private static List<Employee> employees = new()
    {
        new Employee
        {
            Id = 1,
            Name = "Rahul",
            Salary = 50000,
            Permanent = true,
            DateOfBirth = new DateTime(1998, 5, 10)
        },
        new Employee
        {
            Id = 2,
            Name = "Priya",
            Salary = 60000,
            Permanent = true,
            DateOfBirth = new DateTime(1997, 8, 20)
        }
    };

    [HttpGet]
    [Authorize(Roles = "Admin,POC")]
    public ActionResult<List<Employee>> Get()
    {
        return Ok(employees);
    }

    [HttpGet("me")]
    public IActionResult GetMyRole()
    {
        var role = User.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value;
        return Ok(new { role });
    }
}