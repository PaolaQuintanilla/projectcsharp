using Asp.Learning.Commanding.Commands;
using Asp.Learning.Commanding.Queries;
using Asp.Learning.Dtos.requests;
using Asp.Learning.Dtos.responses;
using Asp.Learning.repositories;
using Asp.Learning.repositories.Entities;
using Asp.Learning.utilities;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Learning.Controllers;

//el json que se retorna de los endpoints es la vista en el patron mvc
[ApiController]//simplifies creation of REST apis
//[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class AuthorsController : ControllerBase//para web apis
{
    private readonly Message message;

    public AuthorsController(Message message)
    {
        this.message = message;
    }

    [HttpGet]
    //IActionResult te permite devolver diferentes typos de respuesta
    public IActionResult GetAuthorsV1()
    {
        var response = this.message.DispatchQuery(new FindAuthorsQuery());
        var authorsV1 = response.Select(author => new AuthorV1Dto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            DateOfBirth = author.DateOfBirth,
            DateOfDeath = author.DateOfDeath,
            MainCategory = author.MainCategory,
        });
        return Ok(authorsV1);
    }

    [HttpGet]
    [ApiVersion(2.0, Deprecated = true)]
    //IActionResult te permite devolver diferentes typos de respuesta
    public IActionResult GetAuthorsV2()
    {
        var response = this.message.DispatchQuery(new FindAuthorsQuery());

        var authorsV2 = response.Select(author => new AuthorV2Dto
        {
            Id = author.Id,
            FullName = string.Format("{0} {1}", author.FirstName, author.LastName),
            DateOfBirth = author.DateOfBirth,
            MainCategory = author.MainCategory,
        });
        return Ok(authorsV2);
    }


    [HttpPost]
    public IActionResult PostAuthorsV1(CreateAuthorV1Dto dto)
    {
        var command = new CreateAuthorCommand
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DateOfBirth = dto.DateOfBirth,
            DateOfDeath = dto.DateOfDeath,
            MainCategory = dto.MainCategory,
        };
        var id = this.message.DispatchCommand(command);
        return Ok(id);
    }

    [HttpPost]
    [ApiVersion(2.0, Deprecated = true)]
    public IActionResult PostAuthorsV2(CreateAuthorV2Dto dto)
    {
        string[] values = dto.FullName.Split(',');
        var command = new CreateAuthorCommand
        {
            FirstName = values[0],
            LastName = values[1],
            DateOfBirth = dto.DateOfBirth,
            DateOfDeath = dto.DateOfDeath,
            MainCategory = dto.MainCategory,
        };
        var id = this.message.DispatchCommand(command);
        return Ok(id);
    }
}
