using Asp.Learning.Commanding.Commands;
using Asp.Learning.Commanding.Commands.AddBookToAuthor;
using Asp.Learning.Commanding.Queries;
using Asp.Learning.Contracts;
using Asp.Learning.repositories;
using Asp.Learning.repositories.Entities;
using Asp.Learning.utilities;
using Asp.Versioning;
using Microsoft.EntityFrameworkCore;

namespace Asp.Learning;
public static class HostingExtensions
{
    public static void ConfigureDependencies(this WebApplicationBuilder builder)
    {
        try
        {
            builder.Services.RegisterController();
            builder.Services.RegisterVersioning();
            builder.Services.RegisterSwager();
            builder.RegisterDBContext();
            builder.Services.RegisterRespoitories();
            builder.Services.RegisterCommanding();
            //builder.Services.RegisterCors();
            //builder.Services.RegisterFilters();
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public static void RegisterController(this IServiceCollection services)
    {
        services.AddControllers();
    }


    //agregando service container
    public static void RegisterRespoitories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Author>, AuthorsRepository>();
    }

    public static void RegisterCommanding(this IServiceCollection services)
    {
        services.AddScoped<Message>();
        services.AddScoped<ICommandHandler<CreateAuthorCommand, Guid>, CreateAuthorCommandHandler>();
        services.AddScoped<ICommandHandler<AddBookToAuthorCommand, Guid>, AddBookToAuthorCommandHandler>();
        services.AddScoped<IQueryHandler<FindAuthorsQuery, IReadOnlyList<Author>>, FindAuthorsQueryHandler>();
    }

    public static void RegisterDBContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<LearningDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("conectionDb")));
    }

    //https://localhost:7032/swagger/index.html
    public static void RegisterSwager(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.ConfigureOptions<ConfigureSwaggerOptions>();
    }

    public static void RegisterCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: "AllowSpecificOrigins", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });
        });
    }

    public static void RegisterFilters(this IServiceCollection services)
    {
        //services.AddScoped<LogActionFilter>();
        //services.AddScoped<LoggingResponseHeaderResultFilter>();
        //services.AddScoped<HandlerExceptionFilter>();
    }

    public static void RegisterVersioning(this IServiceCollection services)
    {
        //Asp.Versioning.Mvc.ApiExplorer(for swagger)
        //Asp.Versioning.Mvc(url, query, header, mediatype versioning)
        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new QueryStringApiVersionReader("api-version"),
                new HeaderApiVersionReader("X-Version"),
                new MediaTypeApiVersionReader("X-Version"));
        })
           .AddMvc(options => { })
           .AddApiExplorer(options =>
           {
               options.GroupNameFormat = "'v'VVV";
               options.SubstituteApiVersionInUrl = true;
           });
    }

}
