using StudentManagementApi.Models;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Models.DTOs;
using StudentManagementApi.Services.Interfaces;
using StudentManagementApi.Repositories.Interfaces;
using AutoMapper;

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
            var student = await _studentRepository.GetAllAsync()
                .FirstOrDefaultAsync(s => s.Code == studentCode);
            if (student == null)
                throw new KeyNotFoundException("Student not found.");

            var subjects = await _subjectRepository.GetByStudentIdAsync(student.Id);
            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }

        public async Task<SubjectDto> AddSubjectAsync(CreateSubjectRequest request, int studentId)
        {
            var subject = _mapper.Map<Subject>(request);
            subject.StudentId = studentId;
            subject.LogDetails = $"Created on {DateTime.Now} - {request.LogDetails}";

            var savedSubject = await _subjectRepository.AddAsync(subject);
            return _mapper.Map<SubjectDto>(savedSubject);
        }
    }
}