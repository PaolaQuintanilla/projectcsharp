using Asp.Learning.Services.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Learning.Services.repositories.Configuration
{
    internal class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {
            entity.ToTable("courses");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Title)
                .HasMaxLength(100)
                .HasColumnName("Title")
                .IsRequired();

            entity.Property(p => p.Description)
                .HasMaxLength(200)
                .HasColumnName("Description")
                .IsRequired(false);
        }
    }
}
