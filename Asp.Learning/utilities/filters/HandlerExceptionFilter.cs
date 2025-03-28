using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Asp.Learning.utilities.filters;

public class HandlerExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        // Default response details
        var statusCode = HttpStatusCode.InternalServerError;
        var message = "An unexpected error occurred.";

        // Specific exception handling
        if (context.Exception is ArgumentException)
        {
            statusCode = HttpStatusCode.BadRequest;
            message = "Invalid arguments provided.";
        }
        if (context.Exception is SqlException)
        {
            statusCode = HttpStatusCode.BadRequest;
            message = "The DB conextion is incorrect InvalidOperationException.";
        }
        if (context.Exception is InvalidOperationException)
        {
            statusCode = HttpStatusCode.BadRequest;
            message = "The DB credential is incorrect.";
        }
        if (context.Exception is DbUpdateException)
        {
            statusCode = HttpStatusCode.BadRequest;
            message = "The DB conexion is incorrect.";
        }
        if (context.Exception is KeyNotFoundException)
        {
            statusCode = HttpStatusCode.NotFound;
            message = "Id does not exist.";
        }

        else if (context.Exception is UnauthorizedAccessException)
        {
            statusCode = HttpStatusCode.Unauthorized;
            message = "Unauthorized access.";
        }

        // Create the response object to be sent in the HTTP response
        var response = new
        {
            StatusCode = (int)statusCode,
            Message = message,
            Details = context.Exception.Message // You can customize this depending on your environment (e.g., avoid showing sensitive info in production)
        };

        // Create a JSON result for the HTTP response with the status code
        context.Result = new JsonResult(response)
        {
            StatusCode = (int)statusCode
        };

        // Mark the exception as handled so it doesn't propagate further
        context.ExceptionHandled = true;
    }
}
