using StudentManagementApi.Models;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Models.DTOs;

/// <summary>
/// Interface defining operations for subject business logic.
/// </summary>
namespace StudentManagementApi.Services.Interfaces
{
    public interface ISubjectService
    {
        /// <summary>
        /// Retrieves all subjects associated with a student by their code asynchronously.
        /// </summary>
        /// <param name="studentCode">The unique code of the student.</param>
        /// <returns>A collection of subject DTOs for the student.</returns>
        Task<IEnumerable<SubjectDto>> GetSubjectsByStudentCodeAsync(string studentCode);

        /// <summary>
        /// Adds a new subject for a specific student asynchronously.
        /// </summary>
        /// <param name="request">The request data for the subject.</param>
        /// <param name="studentId">The unique identification number (e.g., ID card or cedula) of the student.</param>
        /// <returns>The DTO of the created subject.</returns>
        Task<SubjectDto> AddSubjectAsync(StudentManagementApi.Models.Requests.CreateSubjectRequest request, string studentId);
    }
}