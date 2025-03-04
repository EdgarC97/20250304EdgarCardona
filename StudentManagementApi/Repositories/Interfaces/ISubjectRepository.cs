using StudentManagementApi.Models;

/// <summary>
/// Interface defining operations for subject data access.
/// </summary>
namespace StudentManagementApi.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        /// <summary>
        /// Retrieves all subjects associated with a student by their identification number (e.g., ID card or cedula) asynchronously.
        /// </summary>
        /// <param name="studentId">The unique identification number of the student (e.g., cedula).</param>
        /// <returns>A collection of subjects associated with the student.</returns>
        Task<IEnumerable<Subject>> GetByStudentIdAsync(string studentId);

        /// <summary>
        /// Adds a new subject to the database asynchronously.
        /// </summary>
        /// <param name="subject">The subject entity to add.</param>
        /// <returns>The added subject entity.</returns>
        Task<Subject> AddAsync(Subject subject);

        /// <summary>
        /// Updates an existing subject in the database asynchronously.
        /// </summary>
        /// <param name="subject">The subject entity to update.</param>
        /// <returns>The updated subject entity, or null if not found.</returns>
        Task<Subject> UpdateAsync(Subject subject);
    }
}