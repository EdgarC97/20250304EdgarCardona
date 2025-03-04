// Models/Student.cs
namespace StudentManagementApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Names { get; set; } = string.Empty;
        public string Lastnames { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public string LogDetails { get; set; } = string.Empty; 
    }
}