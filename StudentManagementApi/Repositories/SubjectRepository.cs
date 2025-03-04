using StudentManagementApi.Data;
using StudentManagementApi.Models;
using StudentManagementApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Repository implementation for subject data access operations.
/// </summary>
namespace StudentManagementApi.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly StudentDbContext _context;

        /// <summary>
        /// Initializes a new instance of the SubjectRepository.
        /// </summary>
        /// <param name="context">The database context for subject operations.</param>
        public SubjectRepository(StudentDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all subjects associated with a student by their identification number (e.g., ID card or cedula) asynchronously.
        /// </summary>
        /// <param name="studentId">The unique identification number of the student (e.g., cedula).</param>
        /// <returns>A collection of subjects associated with the student.</returns>
        public async Task<IEnumerable<Subject>> GetByStudentIdAsync(string studentId)
        {
            return await _context.Subjects
                .Where(s => s.StudentId == studentId)
                .ToListAsync();
        }

        /// <summary>
        /// Adds a new subject to the database asynchronously.
        /// </summary>
        /// <param name="subject">The subject entity to add.</param>
        /// <returns>The added subject entity.</returns>
        public async Task<Subject> AddAsync(Subject subject)
        {
            var result = await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        /// <summary>
        /// Updates an existing subject in the database asynchronously.
        /// </summary>
        /// <param name="subject">The subject entity to update.</param>
        /// <returns>The updated subject entity, or null if not found.</returns>
        public async Task<Subject> UpdateAsync(Subject subject)
        {
            var existingSubject = await _context.Subjects.FindAsync(subject.Id);
            if (existingSubject != null)
            {
                _context.Entry(existingSubject).CurrentValues.SetValues(subject);
                existingSubject.LogDetails = $"Updated on {DateTime.Now} - {subject.LogDetails}";
                await _context.SaveChangesAsync();
            }
            return existingSubject;
        }
    }
}