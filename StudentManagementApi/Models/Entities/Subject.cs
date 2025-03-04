/// <summary>
/// Represents a subject or course associated with a student, including basic details and log information.
/// </summary>
namespace StudentManagementApi.Models
{
    public class Subject
    {
        /// <summary>
        /// The unique identifier for the subject.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The subject's unique code.
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// The name of the subject.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The instructor teaching the subject.
        /// </summary>
        public string Instructor { get; set; } = string.Empty;

        /// <summary>
        /// The schedule or time of the subject.
        /// </summary>
        public string Schedule { get; set; } = string.Empty;

        /// <summary>
        /// The location where the subject is taught.
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// Details of changes or actions logged for the subject.
        /// </summary>
        public string LogDetails { get; set; } = string.Empty; // Detalles de bitácora

        /// <summary>
        /// The identifier of the associated student.
        /// </summary>
        public string StudentId { get; set; }

        /// <summary>
        /// The student associated with this subject.
        /// </summary>
        public Student Student { get; set; }
    }
}