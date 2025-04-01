using Asp.Learning.utilities.filters;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Learning.Controllers;

[ApiController]//simplifies creation of REST apis
[ServiceFilter(typeof(HandlerExceptionFilter))]//filter to catch exception
public class ControllerAPI: ControllerBase
{
}
