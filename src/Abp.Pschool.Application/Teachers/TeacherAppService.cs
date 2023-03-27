using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Abp.Pschool.Teachers
{
    public class TeacherAppService :
        CrudAppService<
            Teacher, //The Teacher entity
            TeacherDto, //Used to show Teachers
            Guid, //Primary key of the Teacher entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateTeacherDto>, //Used to create/update a Teacher
        ITeacherAppService //implement the ITeacherAppService
    {
        public TeacherAppService(IRepository<Teacher, Guid> repository) : base(repository)
        {
        }
    }
}
