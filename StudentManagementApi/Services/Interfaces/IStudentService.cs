using StudentManagementApi.Models;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Models.DTOs;

namespace StudentManagementApi.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> RegisterStudentAsync(int id, CreateStudentRequest request);
        Task<StudentDto> GetStudentByIdAsync(int id);
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
    }
}