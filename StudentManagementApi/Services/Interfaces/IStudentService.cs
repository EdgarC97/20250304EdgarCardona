using StudentManagementApi.Models;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Models.DTOs;

/// <summary>
/// Interface defining operations for student business logic.
/// </summary>
namespace StudentManagementApi.Services.Interfaces
{
    public interface IStudentService
    {
        /// <summary>
        /// Registers or updates a student asynchronously.
        /// </summary>
        /// <param name="id">The unique identification number of the student (e.g., ID card or cedula) provided in the URL.</param>
        /// <param name="request">The request data for the student (excluding ID).</param>
        /// <returns>The DTO of the registered or updated student.</returns>
        Task<StudentDto> RegisterStudentAsync(string id, CreateStudentRequest request);

        /// <summary>
        /// Retrieves a student by their unique identification number (e.g., ID card or cedula) asynchronously.
        /// </summary>
        /// <param name="id">The unique identification number of the student (e.g., cedula).</param>
        /// <returns>The DTO of the student if found, otherwise throws an exception.</returns>
        Task<StudentDto> GetStudentByIdAsync(string id);

        /// <summary>
        /// Retrieves all students asynchronously.
        /// </summary>
        /// <returns>A collection of student DTOs.</returns>
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
    }
}