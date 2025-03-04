using StudentManagementApi.Data;
using StudentManagementApi.Models;
using StudentManagementApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> AddAsync(Student student)
        {
            var result = await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            var existingStudent = await _context.Students.FindAsync(student.Id);
            if (existingStudent != null)
            {
                _context.Entry(existingStudent).CurrentValues.SetValues(student);
                existingStudent.LogDetails = $"Updated on {DateTime.Now} - {student.LogDetails}";
                await _context.SaveChangesAsync();
            }
            return existingStudent;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }
    }
}