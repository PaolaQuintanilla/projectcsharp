using Asp.Learning.Services.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Learning.Services.repositories.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> entity)
    {
        entity.ToTable("Authors");

        entity.HasKey(p => p.Id);

        entity.Property(p => p.FirstName)
            .HasMaxLength(50)
            .HasColumnName("FirstName")
            .IsRequired();

        entity.Property(p => p.LastName)
            .HasMaxLength(50)
            .HasColumnName("LastName")
            .IsRequired();

        entity.Property(p => p.MainCategory)
            .HasMaxLength(30)
            .HasColumnName("Category")
            .IsRequired();

        entity.Property(p => p.DateOfBirth)
            .HasColumnType("datetimeoffset")
            .IsRequired();

        entity.Property(p => p.DateOfDeath)
            .HasColumnType("datetimeoffset")
            .IsRequired(false);

        entity.HasMany(p => p.Courses)
            .WithOne()
            .HasForeignKey("AuthorId")// We need to define fk to avoid adding aditional fk
            .OnDelete(DeleteBehavior.Cascade);
    }
}
