using Asp.Learning.Commanding.Commands.AddBookToAuthor;
using Asp.Learning.Commanding.Commands.CreateAuthor;
using Asp.Learning.Commanding.Commands.DeleteCourseFromAuthor;
using Asp.Learning.Commanding.Queries.FindAuthor;
using Asp.Learning.Commanding.Queries.FindAuthors;
using Asp.Learning.Dtos.requests;
using Asp.Learning.Dtos.responses;
using Asp.Learning.repositories.Entities;
using Asp.Learning.utilities;
using Asp.Learning.utilities.filters;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Learning.Controllers;

//el json que se retorna de los endpoints es la vista en el patron mvc
[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiVersion(2.0, Deprecated = true)]
public class AuthorsController : ControllerAPI//para web apis
{
    private readonly Message message;
    private readonly IMapper _mapper;

    public AuthorsController(Message message, IMapper mapper)
    {
        this.message = message;
        this._mapper = mapper;
    }

    [HttpGet]
    //IActionResult te permite devolver diferentes typos de respuesta
    public async Task<IActionResult> GetAuthorsV1([FromQuery] string? mainCategory = "")
    {
        var response = await this.message.DispatchQuery(new FindAuthorsQuery { MainCategory= mainCategory });
        var authorsV1 = response.Select(author => new AuthorV1Dto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            DateOfBirth = author.DateOfBirth,
            DateOfDeath = author.DateOfDeath,
            MainCategory = author.MainCategory,
            Courses = author.Courses.Select(course => new CourseV1Dto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
            }).ToList()
        });
    
        return Ok(response);
    }

    [HttpGet]
    [MapToApiVersion("2.0")]
    //[ApiVersion(2.0, Deprecated = true)]
    //IActionResult te permite devolver diferentes typos de respuesta
    public async Task<IActionResult> GetAuthorsV2()
    {
        var response = await this.message.DispatchQuery(new FindAuthorsQuery());

        var authorsV2 = response.Select(author => new AuthorV2Dto
        {
            Id = author.Id,
            FullName = string.Format("{0} {1}", author.FirstName, author.LastName),
            DateOfBirth = author.DateOfBirth,
            MainCategory = author.MainCategory,
            Courses = author.Courses.Select(course => new CourseV2Dto
            {
                Id = course.Id,
                Title = course.Title,
            }).ToList()
        });
        return Ok(authorsV2);
    }

    [HttpGet("{authorId}")]
    //[ApiVersion(1.0, Deprecated = true)]
    //IActionResult te permite devolver diferentes typos de respuesta
    public async Task<IActionResult> GetAuthorByIdV1(string authorId)
    {
        var query = new FindAuthorQuery
        {
            Id = Guid.Parse(authorId),
        };

        var response = await this.message.DispatchQuery(query);

        var authorsV2 = new AuthorV1Dto
        {
            Id = response.Id,
            FirstName = response.FirstName,
            LastName = response.LastName,
            DateOfBirth = response.DateOfBirth,
            MainCategory = response.MainCategory,
            Courses = response.Courses.Select(course => new CourseV1Dto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
            }).ToList()
        };

        return Ok(authorsV2);
    }

    [HttpGet("{authorId}")]
    [MapToApiVersion("2.0")]
    //IActionResult te permite devolver diferentes typos de respuesta
    public async Task<IActionResult> GetAuthorByIdV2(string authorId)
    {
        var query = new FindAuthorQuery
        {
            Id = Guid.Parse(authorId),
        };

        var response = await this.message.DispatchQuery(query);

        var authorsV2 = new AuthorV2Dto
        {
            Id = response.Id,
            FullName = string.Format("{0} {1}", response.FirstName, response.LastName),
            DateOfBirth = response.DateOfBirth,
            MainCategory = response.MainCategory,
            Courses = response.Courses.Select(course => new CourseV2Dto
            {
                Id = course.Id,
                Title = course.Title
            }).ToList()
        };

        return Ok(authorsV2);
    }


    [HttpPost]
    [ServiceFilter(typeof(LogActionFilter))]
    public async Task<IActionResult> PostAuthorsV1(CreateAuthorV1Dto dto)
    {
        var authorCommand = _mapper.Map<CreateAuthorCommand>(dto);

        var id = await this.message.DispatchCommand(authorCommand);

        return CreatedAtAction(actionName: nameof(GetAuthorByIdV1), routeValues: new { authorId = id }, value: id);
    }

    [HttpPost]
    [MapToApiVersion("2.0")]
    [ServiceFilter(typeof(LogActionFilter))]
    public async Task<IActionResult> PostAuthorsV2(CreateAuthorV2Dto dto)
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
        var id = await this.message.DispatchCommand(command);
        return Ok(id);
    }

    [HttpPut("{authorId}/courses")]
    [ProducesResponseType(203)]
    [ServiceFilter(typeof(LogActionFilter))]

    public async Task<IActionResult> AddCourseToAuthorV1(string authorId, [FromBody] AddCourseToAuthorV1Dto dto)
    {
        var comand = new AddBookToAuthorCommand
        {
            Title = dto.Title,
            AuthorId = Guid.Parse(authorId),
            Description = dto.Description,
        };
        var result = await this.message.DispatchCommand(comand);

        return NoContent();
    }

    [HttpDelete("{authorId}/courses/{courseId}")]
    [ProducesResponseType(203)]
    [ServiceFilter(typeof(LogActionFilter))]

    public async Task<IActionResult> RemoveCourseFromAuthor(
    string authorId, string courseId)
    {
        var command = new DeleteCourseFromAuthorCommand
        {
            AuthorId = Guid.Parse(authorId),
            CourseId = Guid.Parse(courseId)
        };

        var result = await this.message.DispatchCommand(command);

        return NoContent();
    }
}
