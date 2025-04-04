﻿using Asp.Learning.Commanding.Commands;
using Asp.Learning.Commanding.Commands.AddBookToAuthor;
using Asp.Learning.Commanding.Commands.CreateAuthor;
using Asp.Learning.Commanding.Commands.DeleteCourseFromAuthor;
using Asp.Learning.Commanding.Commands.UpdateAuthor;
using Asp.Learning.Commanding.Queries;
using Asp.Learning.Commanding.Queries.FindAuthor;
using Asp.Learning.Commanding.Queries.FindAuthors;
using Asp.Learning.Contracts.Services;
using Asp.Learning.repositories;
using Asp.Learning.repositories.Services;
using Asp.Learning.Services.domain;
using Asp.Learning.Services.repositories.context;
using Asp.Learning.utilities;
using Asp.Learning.utilities.filters;
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
            builder.Services.RegisterFilters();
            builder.Services.AddControllers(configure =>
            {
                configure.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //builder.Services.RegisterCors();
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public static void RegisterController(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            options.JsonSerializerOptions.MaxDepth = 64; // Opcional, para aumentar la profundidad máxima
        });
    }


    //agregando service container
    public static void RegisterRespoitories(this IServiceCollection services)
    {
        services.AddScoped<RedisCache>();
        services.AddScoped<IWriteRepository<Author>, AuthorsWriteRepository>();
        services.AddScoped<IReadRepository<Author>>(provider =>
            new AuthorsCacheRepository(
                new AuthorsReadRepository(provider.GetService<LearningDbContext>()), provider.GetService<RedisCache>()));
    }

    public static void RegisterCommanding(this IServiceCollection services)
    {
        services.AddScoped<Message>();
        services.AddScoped<ICommandHandler<CreateAuthorCommand, Guid>, CreateAuthorCommandHandler>();
        services.AddScoped<ICommandHandler<AddBookToAuthorCommand, Guid>, AddBookToAuthorCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteCourseFromAuthorCommand, Guid>, DeleteCourseFromAuthorCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateAuthorCommand, Guid>, UpdateAuthorCommandHandler>();
        services.AddScoped<IQueryHandler<FindAuthorsQuery, IReadOnlyList<Author>>, FindAuthorsQueryHandler>();
        services.AddScoped<IQueryHandler<FindAuthorQuery, Author>, FindAuthorQueryHandler>();
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
        services.AddScoped<HandlerExceptionFilter>();
        services.AddScoped<LogActionFilter>();
        //services.AddScoped<LoggingResponseHeaderResultFilter>();
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
