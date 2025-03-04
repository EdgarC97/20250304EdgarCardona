using StudentManagementApi.Models;

namespace StudentManagementApi.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetByIdAsync(int id);
        Task<Student> AddAsync(Student student);
        Task<Student> UpdateAsync(Student student);
        Task<IQueryable<Student>> GetAllAsync(); 
    }
}