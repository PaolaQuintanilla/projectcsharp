using Asp.Learning.Dtos.responses;
using Asp.Learning.repositories;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Learning.Controllers;

//el json que se retorna de los endpoints es la vista en el patron mvc
[ApiController]//simplifies creation of REST apis
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class AuthorsController : ControllerBase//para web apis
{
    private readonly LearningDbContext context;

    public AuthorsController(LearningDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    //IActionResult te permite devolver diferentes typos de respuesta
    public IActionResult GetAuthors()
    {
        var response = this.context.Authors.ToList();
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
        var response = this.context.Authors.ToList();
        var authorsV2 = response.Select(author => new AuthorV2Dto
        {
            Id = author.Id,
            FullName = string.Format("{0} {1}", author.FirstName, author.LastName),
            DateOfBirth = author.DateOfBirth,
            MainCategory = author.MainCategory,
        });
        return Ok(authorsV2);
    }
}
