using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using EmployeeApi.Filters;

namespace EmployeeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[CustomAuthFilter]
public class EmployeeController : ControllerBase
{
    [HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
public ActionResult<List<Employee>> GetStandard()
{
    return Ok(GetStandardEmployeeList());
}

    private List<Employee> GetStandardEmployeeList()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Rahul",
                Salary = 50000,
                Permanent = true,
                DateOfBirth = new DateTime(1998, 5, 10),

                Department = new Department
                {
                    Id = 1,
                    Name = "IT"
                },

                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Id = 1,
                        Name = "C#"
                    },
                    new Skill
                    {
                        Id = 2,
                        Name = "ASP.NET Core"
                    }
                }
            },

            new Employee
            {
                Id = 2,
                Name = "Priya",
                Salary = 60000,
                Permanent = true,
                DateOfBirth = new DateTime(1997, 8, 20),

                Department = new Department
                {
                    Id = 2,
                    Name = "HR"
                },

                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Id = 3,
                        Name = "Recruitment"
                    }
                }
            }
        };
    }

    [HttpPost]
    public IActionResult Post(Employee employee)
    {
        return Ok(employee);
    }

    [HttpPut]
    public IActionResult Put(Employee employee)
    {
        return Ok(employee);
    }
}