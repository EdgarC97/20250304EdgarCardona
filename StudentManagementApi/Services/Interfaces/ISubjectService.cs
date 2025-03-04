using StudentManagementApi.Models;
using StudentManagementApi.Models.DTOs;

namespace StudentManagementApi.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetSubjectsByStudentCodeAsync(string studentCode);
        Task<SubjectDto> AddSubjectAsync(CreateSubjectRequest request, int studentId);
    }
}