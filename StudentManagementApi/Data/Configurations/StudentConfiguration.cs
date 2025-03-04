using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementApi.Models;

namespace StudentManagementApi.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Code).IsRequired().HasMaxLength(20).IsUnicode();
            builder.Property(s => s.Names).IsRequired().HasMaxLength(100).IsUnicode();
            builder.Property(s => s.Lastnames).IsRequired().HasMaxLength(100).IsUnicode();
            builder.Property(s => s.BirthDate).IsRequired();
            builder.Property(s => s.Age).IsRequired();
            builder.Property(s => s.Email).IsRequired().HasMaxLength(100).IsUnicode();
            builder.Property(s => s.LogDetails).HasMaxLength(500).IsUnicode();
            builder.HasIndex(s => s.Code).IsUnique();
            builder.HasIndex(s => s.Email).IsUnique();
        }
    }
}