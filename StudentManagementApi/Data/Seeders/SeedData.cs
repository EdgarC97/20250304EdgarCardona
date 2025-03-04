using StudentManagementApi.Models;

namespace StudentManagementApi.Data.Seeders
{
    public static class SeedData
    {
        public static void Initialize(StudentDbContext context)
        {
            if (context.Students.Any())
                return; 

            // Seed 5 students
            var students = new List<Student>
            {
                new Student
                {
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

            // Seed 5 subjects asociadas al primer estudiante (STU001)
            var subjects = new List<Subject>
            {
                new Subject
                {
                    Code = "MAT001",
                    Name = "Matemáticas",
                    Instructor = "Prof. López",
                    Schedule = "Lunes 10:00",
                    Location = "Aula 101",
                    LogDetails = "Seeded on " + DateTime.Now,
                    StudentId = students[0].Id
                },
                new Subject
                {
                    Code = "FIS001",
                    Name = "Física",
                    Instructor = "Prof. Gómez",
                    Schedule = "Martes 14:00",
                    Location = "Aula 102",
                    LogDetails = "Seeded on " + DateTime.Now,
                    StudentId = students[0].Id
                },
                new Subject
                {
                    Code = "QUI001",
                    Name = "Química",
                    Instructor = "Prof. Pérez",
                    Schedule = "Miércoles 9:00",
                    Location = "Aula 103",
                    LogDetails = "Seeded on " + DateTime.Now,
                    StudentId = students[0].Id
                },
                new Subject
                {
                    Code = "BIO001",
                    Name = "Biología",
                    Instructor = "Prof. Rodríguez",
                    Schedule = "Jueves 16:00",
                    Location = "Aula 104",
                    LogDetails = "Seeded on " + DateTime.Now,
                    StudentId = students[0].Id
                },
                new Subject
                {
                    Code = "INF001",
                    Name = "Informática",
                    Instructor = "Prof. Sánchez",
                    Schedule = "Viernes 11:00",
                    Location = "Aula 105",
                    LogDetails = "Seeded on " + DateTime.Now,
                    StudentId = students[0].Id
                }
            };

            context.Subjects.AddRange(subjects);
            context.SaveChanges();
        }
    }
}