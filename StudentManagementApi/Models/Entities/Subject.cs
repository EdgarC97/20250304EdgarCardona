// Models/Subject.cs
namespace StudentManagementApi.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Instructor { get; set; } = string.Empty;
        public string Schedule { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string LogDetails { get; set; } = string.Empty; 
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}