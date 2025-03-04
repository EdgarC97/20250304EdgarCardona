using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementApi.Models;

/// <summary>
/// Configuration class for Subject entity using Fluent API.
/// </summary>
namespace StudentManagementApi.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        /// <summary>
        /// Configures the Subject entity in the database model.
        /// </summary>
        /// <param name="builder">The entity type builder for the Subject entity.</param>
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Code).IsRequired().HasMaxLength(20).IsUnicode();
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100).IsUnicode();
            builder.Property(s => s.Instructor).IsRequired().HasMaxLength(100).IsUnicode();
            builder.Property(s => s.Schedule).IsRequired().HasMaxLength(100).IsUnicode();
            builder.Property(s => s.Location).IsRequired().HasMaxLength(100).IsUnicode();
            builder.Property(s => s.LogDetails).HasMaxLength(500).IsUnicode();
            builder.Property(s => s.StudentId).IsRequired().HasMaxLength(10).IsUnicode(); 
            builder.HasOne(s => s.Student)
                .WithMany()
                .HasForeignKey(s => s.StudentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}