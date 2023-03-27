using Abp.Pschool.Parents;
using Abp.Pschool.Students;
using AutoMapper;

namespace Abp.Pschool;

public class PschoolApplicationAutoMapperProfile : Profile
{
    public PschoolApplicationAutoMapperProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<CreateUpdateStudentDto, Student>();
        CreateMap<Parent, ParentDto>();
        CreateMap<CreateUpdateParentDto, Parent>();
    }
}
