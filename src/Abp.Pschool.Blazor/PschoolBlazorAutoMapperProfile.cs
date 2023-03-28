using Abp.Pschool.Students;
using Abp.Pschool.Teachers;
using AutoMapper;

namespace Abp.Pschool.Blazor;

public class PschoolBlazorAutoMapperProfile : Profile
{
    public PschoolBlazorAutoMapperProfile()
    {
        CreateMap<StudentDto, CreateUpdateStudentDto>();

        CreateMap<TeacherDto, CreateTeacherDto>();
        CreateMap<TeacherDto, UpdateTeacherDto>();
    }
}
