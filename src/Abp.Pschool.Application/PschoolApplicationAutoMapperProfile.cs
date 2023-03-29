using Abp.Pschool.Students;
using Abp.Pschool.Teachers;
using AutoMapper;

namespace Abp.Pschool;

public class PschoolApplicationAutoMapperProfile : Profile
{
    public PschoolApplicationAutoMapperProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<CreateUpdateStudentDto, Student>();


        CreateMap<Teacher, TeacherDto>();
        CreateMap<CreateTeacherDto, Teacher>();
        CreateMap<UpdateTeacherDto, Teacher>();
        CreateMap<Teacher, TeacherLookupDto>();
    }
}
