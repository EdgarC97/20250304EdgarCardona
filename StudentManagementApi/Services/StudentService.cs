using StudentManagementApi.Models;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Models.DTOs;
using StudentManagementApi.Services.Interfaces;
using StudentManagementApi.Repositories.Interfaces;
using AutoMapper;

namespace StudentManagementApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentDto> RegisterStudentAsync(int id, CreateStudentRequest request)
        {
            var student = _mapper.Map<Student>(request);
            student.Id = id;
            student.LogDetails = $"Created on {DateTime.Now} - {request.LogDetails}";

            var savedStudent = await _studentRepository.AddAsync(student);
            return _mapper.Map<StudentDto>(savedStudent);
        }

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
                throw new KeyNotFoundException("Student not found.");
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }
    }
}