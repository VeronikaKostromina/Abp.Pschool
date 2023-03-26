using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Abp.Pschool.Parents
{
    public interface IParentAppService :
        ICrudAppService< //Defines CRUD methods
            ParentDto, //Used to show parents
            Guid, //Primary key of the parent entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateParentDto> //Used to create/update a parent
    {
    }
}
