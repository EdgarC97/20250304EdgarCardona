using StudentManagementApi.Data;
using StudentManagementApi.Models;
using StudentManagementApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Repository implementation for student data access operations.
/// </summary>
namespace StudentManagementApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        /// <summary>
        /// Initializes a new instance of the StudentRepository.
        /// </summary>
        /// <param name="context">The database context for student operations.</param>
        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a student by their unique identification number (e.g., ID card or cedula) asynchronously.
        /// </summary>
        /// <param name="id">The unique identification number of the student (e.g., cedula).</param>
        /// <returns>The student entity if found, otherwise null.</returns>
        public async Task<Student> GetByIdAsync(string id)
        {
            return await _context.Students.FindAsync(id);
        }

        /// <summary>
        /// Adds a new student to the database asynchronously.
        /// </summary>
        /// <param name="student">The student entity to add.</param>
        /// <returns>The added student entity.</returns>
        public async Task<Student> AddAsync(Student student)
        {
            var result = await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        /// <summary>
        /// Updates an existing student in the database asynchronously.
        /// </summary>
        /// <param name="student">The student entity to update.</param>
        /// <returns>The updated student entity, or null if not found.</returns>
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

        /// <summary>
        /// Retrieves all students as a queryable collection asynchronously.
        /// </summary>
        /// <returns>A queryable collection of all students.</returns>
        public Task<IQueryable<Student>> GetAllAsync()
        {
            return Task.FromResult(_context.Students.AsQueryable());
        }
    }
}