using AutoMapper;
using StudentManagementApi.Models;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Models.DTOs;

namespace StudentManagementApi.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateStudentRequest, Student>();
            CreateMap<Student, StudentDto>();
            CreateMap<CreateSubjectRequest, Subject>();
            CreateMap<Subject, SubjectDto>();
        }
    }
}