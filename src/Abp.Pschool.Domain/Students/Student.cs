using System;
using Abp.Pschool.Parents;
using Abp.Pschool.StudentDocuments;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abp.Pschool.Students
{
    public class Student : AuditedAggregateRoot<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int ClassNumber { get; set; }
        public string? Email { get; set; }

        public Guid ParentId { get; set; }
        public Parent? Parent { get; set; }
        public StudentDocument? StudentDocument { get; set; }
        public StudentMarkType? StudentMarkType { get; set; }
    }
}
