namespace StudentManagementApi.Models.DTOs
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Instructor { get; set; } = string.Empty;
        public string Schedule { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string LogDetails { get; set; } = string.Empty; 
        public string StudentId { get; set; }
    }
}