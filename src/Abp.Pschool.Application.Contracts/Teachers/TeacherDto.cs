using System;
using Volo.Abp.Application.Dtos;

namespace Abp.Pschool.Teachers
{
    public class TeacherDto : AuditedEntityDto<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? HomeAddress { get; set; }
        public string? Phone { get; set; }
    }
}
