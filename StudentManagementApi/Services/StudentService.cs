using StudentManagementApi.Models;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Models.DTOs;
using StudentManagementApi.Services.Interfaces;
using StudentManagementApi.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Service implementation for student business logic operations.
/// </summary>
namespace StudentManagementApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the StudentService.
        /// </summary>
        /// <param name="studentRepository">The repository for student data access.</param>
        /// <param name="mapper">The AutoMapper instance for object mapping.</param>
        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Registers or updates a student asynchronously.
        /// </summary>
        /// <param name="id">The unique identification number of the student (e.g., ID card or cedula) provided in the URL.</param>
        /// <param name="request">The request data for the student (excluding ID).</param>
        /// <returns>The DTO of the registered or updated student.</returns>
        public async Task<StudentDto> RegisterStudentAsync(string id, CreateStudentRequest request)
        {
            var student = _mapper.Map<Student>(request);
            student.Id = id; // Usa el ID (cédula) de la URL
            student.LogDetails = $"Created on {DateTime.Now} - {request.LogDetails}";

            // Check if the student exists (for updates)
            var existingStudent = await _studentRepository.GetByIdAsync(id);
            if (existingStudent != null)
            {
                existingStudent.Code = student.Code; // Actualiza los campos manualmente
                existingStudent.Names = student.Names;
                existingStudent.Lastnames = student.Lastnames;
                existingStudent.BirthDate = student.BirthDate;
                existingStudent.Age = student.Age;
                existingStudent.Email = student.Email;
                existingStudent.LogDetails = $"Updated on {DateTime.Now} - {student.LogDetails}";
                var updatedStudent = await _studentRepository.UpdateAsync(existingStudent);
                return _mapper.Map<StudentDto>(updatedStudent);
            }

            // For new students, use the provided ID (cedula) from the URL
            var savedStudent = await _studentRepository.AddAsync(student);
            return _mapper.Map<StudentDto>(savedStudent);
        }

        /// <summary>
        /// Retrieves a student by their unique identification number (e.g., ID card or cedula) asynchronously.
        /// </summary>
        /// <param name="id">The unique identification number of the student (e.g., cedula).</param>
        /// <returns>The DTO of the student if found, otherwise throws an exception.</returns>
        public async Task<StudentDto> GetStudentByIdAsync(string id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
                throw new KeyNotFoundException("Student not found.");
            return _mapper.Map<StudentDto>(student);
        }

        /// <summary>
        /// Retrieves all students asynchronously.
        /// </summary>
        /// <returns>A collection of student DTOs.</returns>
        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }
    }
}