using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Abp.Pschool.Teachers
{
    public interface ITeacherAppService :
        ICrudAppService< //Defines CRUD methods
            TeacherDto, //Used to show Teachers
            Guid, //Primary key of the Teacher entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateTeacherDto> //Used to create/update a Teacher
    {
    }
}
