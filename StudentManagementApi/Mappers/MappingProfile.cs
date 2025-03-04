using AutoMapper;
using StudentManagementApi.Models;
using StudentManagementApi.Models.Requests;
using StudentManagementApi.Models.DTOs;

/// <summary>
/// Configuration profile for AutoMapper to define mappings between models, requests, and DTOs.
/// </summary>
namespace StudentManagementApi.Mappers
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the MappingProfile and defines mapping rules.
        /// </summary>
        public MappingProfile()
        {
            // Map from CreateStudentRequest to Student (do not map Id, it comes from the URL)
            CreateMap<CreateStudentRequest, Student>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Names, opt => opt.MapFrom(src => src.Names))
                .ForMember(dest => dest.Lastnames, opt => opt.MapFrom(src => src.Lastnames))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.LogDetails, opt => opt.MapFrom(src => src.LogDetails));

            // Map from Student to StudentDto
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Names, opt => opt.MapFrom(src => src.Names))
                .ForMember(dest => dest.Lastnames, opt => opt.MapFrom(src => src.Lastnames))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.LogDetails, opt => opt.MapFrom(src => src.LogDetails));

            // Map from CreateSubjectRequest to Subject
            CreateMap<CreateSubjectRequest, Subject>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Instructor, opt => opt.MapFrom(src => src.Instructor))
                .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => src.Schedule))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.LogDetails, opt => opt.MapFrom(src => src.LogDetails));

            // Map from Subject to SubjectDto
            CreateMap<Subject, SubjectDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Instructor, opt => opt.MapFrom(src => src.Instructor))
                .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => src.Schedule))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.LogDetails, opt => opt.MapFrom(src => src.LogDetails))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId));
        }
    }
}