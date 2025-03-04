/// <summary>
/// Request model for creating or updating a student.
/// </summary>
namespace StudentManagementApi.Models.Requests
{
    public class CreateStudentRequest
    {

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
        /// Details of changes or actions to log for the student.
        /// </summary>
        public string LogDetails { get; set; } = string.Empty; // Detalles de bitácora
    }
}