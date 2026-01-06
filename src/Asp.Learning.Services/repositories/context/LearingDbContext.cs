using Asp.Learning.Services.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Asp.Learning.Services.repositories.context;

public class LearningDbContext : DbContext
{
    private readonly string connection;
    private readonly bool useConsole;

    public LearningDbContext(DbContextOptions<LearningDbContext> dbContext)
        :base(dbContext)
    {
        
    }
    public LearningDbContext(string connection, bool useConsole)
    {
        this.connection = connection;
        this.useConsole = useConsole;
    }

    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //This is already tested in unit test scenarios
        //So just configure for sql server
        if (!optionsBuilder.IsConfigured)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                    .AddConsole();
            });

            optionsBuilder
                .UseSqlServer(connection,
                    sqlOptions => sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,         // Maximum number of retry attempts
                        maxRetryDelay: TimeSpan.FromSeconds(15), // Max delay between retries
                        errorNumbersToAdd: null
                    )
                );
            //.UseLazyLoadingProxies();//To enable lazy loading (Only writes, never reads)

            if (useConsole)
            {
                optionsBuilder
                    .UseLoggerFactory(loggerFactory)
                    .EnableSensitiveDataLogging();//Now we can see the sql query on the console for performance purposes
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(LearningDbContext).Assembly,
            WriteConfigurationsFilter);


        // seed the database with dummy data
        modelBuilder.Entity<Author>().HasData(
            Author.CreateNew("Berry", "Griffin Beak Eldritch", "Ships", new DateTime(1978, 5, 21), new DateTime(1978, 5, 21)),
            Author.CreateNew("Nancy", "Swashbuckler Rye", "Rum", new DateTime(1978, 5, 21), new DateTime(1978, 5, 21)),
            Author.CreateNew("Eli", "Ivory Bones Sweet", "Singing", new DateTime(1978, 5, 21), new DateTime(1978, 5, 21)));

        modelBuilder.Entity<Course>().HasData(
           Course.CreateNew("Commandeering a Ship Without Getting Caught", "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers."),
           Course.CreateNew("Singalong Pirate Hits", "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers."));
        base.OnModelCreating(modelBuilder);
    }


    private static bool WriteConfigurationsFilter(Type type) =>
        type.FullName?.Contains("repositories.Configuration") ?? false;

}
