using Asp.Learning.Contracts.Services;
using Asp.Learning.GraphQL.Queries;
using Asp.Learning.repositories;
using Asp.Learning.repositories.Services;
using Asp.Learning.Services.domain;
using Asp.Learning.Services.repositories.context;
using Microsoft.EntityFrameworkCore;
//https://chillicream.com/docs/hotchocolate/v13/defining-a-schema/object-types
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<AuthorQuery>();

builder.Services.AddScoped<RedisCache>();
//builder.Services.AddScoped<IWriteRepository<Author>, AuthorsWriteRepository>();
builder.Services.AddScoped<IReadRepository<Author>>(provider =>
    new AuthorsCacheRepository(
        new AuthorsReadRepository(provider.GetService<LearningDbContext>()), provider.GetService<RedisCache>()));

builder.Services.AddDbContext<LearningDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conectionDb")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowSpecificOrigins", builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<AuthorQuery>()
    //.AddMutationType<Mutation>()
    .AddDefaultTransactionScopeHandler()
    .AddMutationConventions(applyToAllMutations: true);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigins");

app.UseRouting(); // Required for HotChocolate

app.MapGraphQL(); // Maps the GraphQL endpoint

app.Run();
