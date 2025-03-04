using StudentManagementApi.Data;
using StudentManagementApi.Models;

/// <summary>
/// Static class to seed initial data into the database.
/// </summary>
namespace StudentManagementApi.Data.Seeders
{
    public static class SeedData
    {
        /// <summary>
        /// Initializes the database with sample student and subject data if no students exist.
        /// </summary>
        /// <param name="context">The database context to seed data into.</param>
        public static void Initialize(StudentDbContext context)
        {
            if (context.Students.Any())
                return; // Avoid duplicates

            // Seed 5 students with cedulas as IDs
            var students = new List<Student>
            {
                new Student
                {
                    Id = "123456789", // Ejemplo de cédula
                    Code = "STU001",
                    Names = "Juan",
                    Lastnames = "Pérez",
                    BirthDate = new DateTime(2000, 1, 1),
                    Age = 23,
                    Email = "juan.perez@example.com",
                    LogDetails = "Seeded on " + DateTime.Now
                },
                new Student
                {
                    Id = "987654321", // Ejemplo de cédula
                    Code = "STU002",
                    Names = "María",
                    Lastnames = "Gómez",
                    BirthDate = new DateTime(2001, 5, 15),
                    Age = 22,
                    Email = "maria.gomez@example.com",
                    LogDetails = "Seeded on " + DateTime.Now
                },
                new Student
                {
                    Id = "456789123", // Ejemplo de cédula
                    Code = "STU003",
                    Names = "Pedro",
                    Lastnames = "López",
                    BirthDate = new DateTime(1999, 8, 20),
                    Age = 24,
                    Email = "pedro.lopez@example.com",
                    LogDetails = "Seeded on " + DateTime.Now
                },
                new Student
                {
                    Id = "789123456", // Ejemplo de cédula
                    Code = "STU004",
                    Names = "Ana",
                    Lastnames = "Rodríguez",
                    BirthDate = new DateTime(2002, 3, 10),
                    Age = 21,
                    Email = "ana.rodriguez@example.com",
                    LogDetails = "Seeded on " + DateTime.Now
                },
                new Student
                {
                    Id = "321654987", // Ejemplo de cédula
                    Code = "STU005",
                    Names = "Carlos",
                    Lastnames = "Sánchez",
                    BirthDate = new DateTime(2000, 12, 5),
                    Age = 23,
                    Email = "carlos.sanchez@example.com",
                    LogDetails = "Seeded on " + DateTime.Now
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            // Seed 5 subjects associated with the first student (cedula "123456789")
            var subjects = new List<Subject>
            {
                new Subject
                {
                    Code = "MAT001",
                    Name = "Mathematics",
                    Instructor = "Prof. López",
                    Schedule = "Monday 10:00",
                    Location = "Room 101",
                    LogDetails = "Seeded on " + DateTime.Now,
                    StudentId = "123456789" // Usa la cédula como StudentId
                },
                new Subject
                {
                    Code = "PHY001",
                    Name = "Physics",
                    Instructor = "Prof. Gómez",
                    Schedule = "Tuesday 14:00",
                    Location = "Room 102",
                    LogDetails = "Seeded on " + DateTime.Now,
                    StudentId = "123456789"
                },
                new Subject
                {
                    Code = "CHE001",
                    Name = "Chemistry",
                    Instructor = "Prof. Pérez",
                    Schedule = "Wednesday 9:00",
                    Location = "Room 103",
                    LogDetails = "Seeded on " + DateTime.Now,
                    StudentId = "123456789"
                },
                new Subject
                {
                    Code = "BIO001",
                    Name = "Biology",
                    Instructor = "Prof. Rodríguez",
                    Schedule = "Thursday 16:00",
                    Location = "Room 104",
                    LogDetails = "Seeded on " + DateTime.Now,
                    StudentId = "123456789"
                },
                new Subject
                {
                    Code = "INF001",
                    Name = "Computer Science",
                    Instructor = "Prof. Sánchez",
                    Schedule = "Friday 11:00",
                    Location = "Room 105",
                    LogDetails = "Seeded on " + DateTime.Now,
                    StudentId = "123456789"
                }
            };

            context.Subjects.AddRange(subjects);
            context.SaveChanges();
        }
    }
}