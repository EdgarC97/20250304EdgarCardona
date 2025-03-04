using StudentManagementApi.Models;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Models.DTOs;
using StudentManagementApi.Services.Interfaces;
using StudentManagementApi.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Service implementation for subject business logic operations.
/// </summary>
namespace StudentManagementApi.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the SubjectService.
        /// </summary>
        /// <param name="subjectRepository">The repository for subject data access.</param>
        /// <param name="studentRepository">The repository for student data access.</param>
        /// <param name="mapper">The AutoMapper instance for object mapping.</param>
        public SubjectService(ISubjectRepository subjectRepository, IStudentRepository studentRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all subjects associated with a student by their code asynchronously.
        /// </summary>
        /// <param name="studentCode">The unique code of the student.</param>
        /// <returns>A collection of subject DTOs for the student.</returns>
        public async Task<IEnumerable<SubjectDto>> GetSubjectsByStudentCodeAsync(string studentCode)
        {
            var students = await _studentRepository.GetAllAsync();
            var student = await students.FirstOrDefaultAsync(s => s.Code == studentCode);
            if (student == null)
                throw new KeyNotFoundException("Student not found.");

            var subjects = await _subjectRepository.GetByStudentIdAsync(student.Id);
            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }

        /// <summary>
        /// Adds a new subject for a specific student asynchronously.
        /// </summary>
        /// <param name="request">The request data for the subject.</param>
        /// <param name="studentId">The unique identification number (e.g., ID card or cedula) of the student.</param>
        /// <returns>The DTO of the created subject.</returns>
        public async Task<SubjectDto> AddSubjectAsync(StudentManagementApi.Models.Requests.CreateSubjectRequest request, string studentId)
        {
            // Verifica si el estudiante existe
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student == null)
                throw new KeyNotFoundException("Student not found.");

            var subject = _mapper.Map<Subject>(request);
            subject.StudentId = studentId;
            subject.LogDetails = $"Created on {DateTime.Now} - {request.LogDetails}";

            var savedSubject = await _subjectRepository.AddAsync(subject);
            return _mapper.Map<SubjectDto>(savedSubject);
        }
    }
}