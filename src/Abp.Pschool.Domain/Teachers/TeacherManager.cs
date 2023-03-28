using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Abp.Pschool.Teachers
{
    public class TeacherManager : DomainService
    {
        private readonly ITeacherRepository teacherRepository;

        public TeacherManager(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public async Task<Teacher> CreateAsync([NotNull] string firstName,
                                               [NotNull] string lastName,
                                               [NotNull] string email)
        {
            Check.NotNullOrWhiteSpace(firstName, nameof(firstName));
            Check.NotNullOrWhiteSpace(lastName, nameof(lastName));
            Check.NotNullOrWhiteSpace(email, nameof(email));

            var existingTeacher = await teacherRepository.FindByLastNameAsync(lastName);
            if (existingTeacher != null)
            {
                throw new TeacherAlreadyExistsException(firstName, lastName);
            }

            return new Teacher(GuidGenerator.Create(), firstName, lastName, email);
        }

        public async Task ChangeNameAsync(
            [NotNull] Teacher teacher,
            [NotNull] string firstName,
            [NotNull] string lastName)
        {
            Check.NotNull(teacher, nameof(teacher));
            Check.NotNullOrWhiteSpace(firstName, nameof(firstName));
            Check.NotNullOrWhiteSpace(lastName, nameof(lastName));

            var existingTeacher = await teacherRepository.FindByLastNameAsync(lastName);
            if (existingTeacher != null && existingTeacher.Id != teacher.Id)
            {
                throw new TeacherAlreadyExistsException(firstName, lastName);
            }

            teacher.ChangeFullName(firstName, lastName);
        }
    }
}
