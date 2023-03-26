using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Abp.Pschool.Students
{
    public interface IStudentAppService :
        ICrudAppService< //Defines CRUD methods
            StudentDto, //Used to show students
            Guid, //Primary key of the student entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateStudentDto> //Used to create/update a student
    {
    }
}
