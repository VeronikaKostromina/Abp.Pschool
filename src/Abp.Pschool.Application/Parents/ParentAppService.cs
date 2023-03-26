using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Abp.Pschool.Parents
{
    public class ParentAppService :
        CrudAppService<
            Parent, //The Parent entity
            ParentDto, //Used to show parents
            Guid, //Primary key of the parent entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateParentDto>, //Used to create/update a parent
        IParentAppService //implement the IParentAppService
    {
        public ParentAppService(IRepository<Parent, Guid> repository) : base(repository)
        {
        }
    }
}
