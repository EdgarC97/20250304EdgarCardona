using StudentManagementApi.Models;

/// <summary>
/// Interface defining operations for student data access.
/// </summary>
namespace StudentManagementApi.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        /// <summary>
        /// Retrieves a student by their unique identification number (e.g., ID card or cedula) asynchronously.
        /// </summary>
        /// <param name="id">The unique identification number of the student (e.g., cedula).</param>
        /// <returns>The student entity if found, otherwise null.</returns>
        Task<Student> GetByIdAsync(string id);

        /// <summary>
        /// Adds a new student to the database asynchronously.
        /// </summary>
        /// <param name="student">The student entity to add.</param>
        /// <returns>The added student entity.</returns>
        Task<Student> AddAsync(Student student);

        /// <summary>
        /// Updates an existing student in the database asynchronously.
        /// </summary>
        /// <param name="student">The student entity to update.</param>
        /// <returns>The updated student entity, or null if not found.</returns>
        Task<Student> UpdateAsync(Student student);

        /// <summary>
        /// Retrieves all students as a queryable collection asynchronously.
        /// </summary>
        /// <returns>A queryable collection of all students.</returns>
        Task<IQueryable<Student>> GetAllAsync();
    }
}