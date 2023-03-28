using System;
using System.Threading.Tasks;
using Abp.Pschool.Students;
using Abp.Pschool.Teachers;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Abp.Pschool
{
    public class StudentStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Student, Guid> studentRepository;
        private readonly ITeacherRepository teacherRepository;
        private readonly TeacherManager teacherManager;

        public StudentStoreDataSeederContributor(IRepository<Student, Guid> studentRepository,
                                                 ITeacherRepository teacherRepository,
                                                 TeacherManager teacherManager)
        {
            this.studentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
            this.teacherManager = teacherManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {

            if (await teacherRepository.GetCountAsync() <= 0)
            {
                var teacher1 = await teacherManager.CreateAsync(
                    "James",
                    "Wilson",
                    "wilson@gmail.com"
                );
                teacher1.Phone = "85463546";
                teacher1.HomeAddress = "UK, Glazgo";

                await teacherRepository.InsertAsync(teacher1);

                var teacher2 = await teacherManager.CreateAsync(
                    "Robert",
                    "Taylor",
                    "taylor@gmail.com"
                );
                teacher2.Phone = "3993319";
                teacher2.HomeAddress = "UK, Glazgo";

                await teacherRepository.InsertAsync(teacher2);

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
                            Teacher = teacher1
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
                            Teacher = teacher2
                        },
                        autoSave: true
                    );
                }
            }
        }
    }
}