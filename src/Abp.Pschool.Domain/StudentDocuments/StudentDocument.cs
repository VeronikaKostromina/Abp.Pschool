using System;
using Abp.Pschool.Students;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abp.Pschool.StudentDocuments
{
    public class StudentDocument : AuditedAggregateRoot<Guid>
    {
        public string? FileName { get; set; }
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
