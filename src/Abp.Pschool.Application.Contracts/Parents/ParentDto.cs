using System;
using Volo.Abp.Application.Dtos;

namespace Abp.Pschool.Parents
{
    public class ParentDto : AuditedEntityDto<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? HomeAddress { get; set; }
        public string? Phone { get; set; }
    }
}
