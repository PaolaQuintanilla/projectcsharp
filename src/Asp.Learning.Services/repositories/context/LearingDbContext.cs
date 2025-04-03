using Asp.Learning.Services.domain;
using Microsoft.EntityFrameworkCore;

namespace Asp.Learning.Services.repositories.context;

public class LearningDbContext : DbContext
{
    public LearningDbContext(DbContextOptions<LearningDbContext> options)
       : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;


    private static bool WriteConfigurationsFilter(Type type) =>
        type.FullName?.Contains("repositories.Configuration") ?? false;

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
}
