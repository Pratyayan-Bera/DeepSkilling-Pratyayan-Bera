using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeApi.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        string filePath = "ErrorLog.txt";

        File.AppendAllText(
            filePath,
            $"[{DateTime.Now}] {context.Exception.Message}{Environment.NewLine}"
        );

        context.Result = new ObjectResult(new
        {
            Message = "An internal server error occurred."
        })
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}