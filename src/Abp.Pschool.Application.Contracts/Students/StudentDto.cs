using System;
using Volo.Abp.Application.Dtos;

namespace Abp.Pschool.Students
{
    public class StudentDto : AuditedEntityDto<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int ClassNumber { get; set; }
        public Guid ParentId { get; set; }
        public string? ParentFullName { get; set; }
        public string? Email { get; set; }

    }
}
