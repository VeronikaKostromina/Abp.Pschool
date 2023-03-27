using System;
using System.Threading.Tasks;
using Abp.Pschool.Teachers;
using Abp.Pschool.Students;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Abp.Pschool
{
    public class StudentStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Student, Guid> studentRepository;

        public StudentStoreDataSeederContributor(IRepository<Student, Guid> studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await studentRepository.GetCountAsync() <= 0)
            {
                await studentRepository.InsertAsync(
                    new Student()
                    {
                        FirstName = "Bob",
                        LastName = "Jones",
                        ClassNumber = 1,
                        Email = "jones@gmail.com",
                        Type = StudentMarkType.Excellent,
                        Teacher = new Teacher()
                        {
                            FirstName = "BobTeacher",
                            LastName = "Jones",
                            Email = "Teacher1@gmail.com"
                        }
                    },
                    autoSave: true
                );

                await studentRepository.InsertAsync(
                    new Student()
                    {
                        FirstName = "Tom",
                        LastName = "Smith",
                        ClassNumber = 10,
                        Email = "smith@gmail.com",
                        Type = StudentMarkType.Satisfactory,
                        Teacher = new Teacher()
                        {
                            FirstName = "TomTeacher",
                            LastName = "Smith",
                            Email = "Teacher2@gmail.com"
                        }
                    },
                    autoSave: true
                );
            }
        }
    }
}