using StudentManagementApi.Data;
using StudentManagementApi.Models;
using StudentManagementApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementApi.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly StudentDbContext _context;

        public SubjectRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetByStudentIdAsync(int studentId)
        {
            return await _context.Subjects
                .Where(s => s.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<Subject> AddAsync(Subject subject)
        {
            var result = await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

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