/// <summary>
/// Represents a student with basic information and log details.
/// </summary>
namespace StudentManagementApi.Models
{
    public class Student
    {
        /// <summary>
        /// The unique identifier for the student.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The student's unique code.
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// The student's first names.
        /// </summary>
        public string Names { get; set; } = string.Empty;

        /// <summary>
        /// The student's last names.
        /// </summary>
        public string Lastnames { get; set; } = string.Empty;

        /// <summary>
        /// The student's date of birth.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// The student's age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// The student's email address.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Details of changes or actions logged for the student.
        /// </summary>
        public string LogDetails { get; set; } = string.Empty; // Detalles de bitácora
    }
}