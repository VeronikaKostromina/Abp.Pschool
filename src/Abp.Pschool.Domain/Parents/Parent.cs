using System;
using System.Collections.Generic;
using Abp.Pschool.Students;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abp.Pschool.Parents
{
    public class Parent : AuditedAggregateRoot<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public string? Email { get; set; }
        public string? HomeAddress { get; set; }
        public string? Phone { get; set; }
    }
}
