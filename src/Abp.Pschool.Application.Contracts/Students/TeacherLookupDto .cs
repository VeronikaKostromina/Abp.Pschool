using System;
using Volo.Abp.Application.Dtos;

namespace Abp.Pschool.Students
{
    public class TeacherLookupDto : EntityDto<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
