using StudentManagementApi.Models;

namespace StudentManagementApi.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetByStudentIdAsync(int studentId);
        Task<Subject> AddAsync(Subject subject);
        Task<Subject> UpdateAsync(Subject subject);
    }
}