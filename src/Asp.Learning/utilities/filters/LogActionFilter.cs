using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Asp.Learning.utilities.filters;
public class LogActionFilter : IActionFilter
{
    private Stopwatch stopwatch;

    public void OnActionExecuting(ActionExecutingContext context)
    {
        stopwatch = Stopwatch.StartNew();
        Debug.WriteLine("Action execution started.");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        stopwatch.Stop();
        var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
        Debug.WriteLine("Action execution finished.");
        Debug.WriteLine($"Action took {elapsedMilliseconds} ms to execute.");
    }
}