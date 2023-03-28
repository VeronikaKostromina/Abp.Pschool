using System;
using System.Collections.Generic;
using Abp.Pschool.Students;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abp.Pschool.Teachers
{
    public class Teacher : FullAuditedAggregateRoot<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public string? Email { get; set; }
        public string? HomeAddress { get; set; }
        public string? Phone { get; set; }

        private Teacher()
        {

        }

        internal Teacher(Guid id, [NotNull] string firstName, [NotNull] string lastName, [NotNull] string email) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        internal Teacher ChangeFullName([NotNull] string firstName, [NotNull] string lastName)
        {
            SetFullName(firstName, lastName);
            return this;
        }

        private void SetFullName([NotNull] string firstName, [NotNull] string lastName)
        {
            FirstName = Check.NotNullOrWhiteSpace(
                firstName,
                nameof(firstName),
                maxLength: TeachersConst.MaxNameLength
            );
            LastName = Check.NotNullOrWhiteSpace(
                lastName,
                nameof(lastName),
                maxLength: TeachersConst.MaxNameLength
            );
        }
    }
}
