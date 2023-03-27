using System;
using System.Threading.Tasks;
using Abp.Pschool.Parents;
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
                        StudentMarkType = StudentMarkType.Excellent,
                        Parent = new Parent()
                        {
                            FirstName = "BobParent",
                            LastName = "Jones",
                            Email = "parent1@gmail.com"
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
                        StudentMarkType = StudentMarkType.Satisfactory,
                        Parent = new Parent()
                        {
                            FirstName = "TomParent",
                            LastName = "Smith",
                            Email = "parent2@gmail.com"
                        }
                    },
                    autoSave: true
                );
            }
        }
    }
}