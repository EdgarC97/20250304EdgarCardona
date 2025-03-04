using StudentManagementApi.Models;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Models.DTOs;
using StudentManagementApi.Services.Interfaces;
using StudentManagementApi.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore; // Asegúrate de incluir este using

namespace StudentManagementApi.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectRepository, IStudentRepository studentRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectDto>> GetSubjectsByStudentCodeAsync(string studentCode)
        {
            var students = await _studentRepository.GetAllAsync(); // Resuelve el Task<IQueryable<Student>>
            var student = await students.FirstOrDefaultAsync(s => s.Code == studentCode); // Usa FirstOrDefaultAsync en IQueryable
            if (student == null)
                throw new KeyNotFoundException("Student not found.");

            var subjects = await _subjectRepository.GetByStudentIdAsync(student.Id);
            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }

        public async Task<SubjectDto> AddSubjectAsync(StudentManagementApi.Models.Requests.CreateSubjectRequest request, int studentId)
        {
            var subject = _mapper.Map<Subject>(request);
            subject.StudentId = studentId;
            subject.LogDetails = $"Created on {DateTime.Now} - {request.LogDetails}";

            var savedSubject = await _subjectRepository.AddAsync(subject);
            return _mapper.Map<SubjectDto>(savedSubject);
        }
    }
}