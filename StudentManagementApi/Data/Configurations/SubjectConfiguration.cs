using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementApi.Models;

namespace StudentManagementApi.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
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
            builder.HasOne(s => s.Student)
                .WithMany()
                .HasForeignKey(s => s.StudentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}