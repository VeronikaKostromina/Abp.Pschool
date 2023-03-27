using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace Abp.Pschool.Teachers
{
    public class TeacherAppService_Tests : PschoolApplicationTestBase
    {
        private readonly ITeacherAppService TeacherAppService;

        public TeacherAppService_Tests()
        {
            this.TeacherAppService = GetRequiredService<ITeacherAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Teachers()
        {
            //Act
            var result = await TeacherAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.FirstName == "BobTeacher");
        }

        [Fact]
        public async Task Should_Create_A_Valid_Teacher()
        {
            //Act
            var result = await TeacherAppService.CreateAsync(
                new CreateUpdateTeacherDto
                {
                    FirstName = "GlenTeacher",
                    LastName = "Anderson",
                    Email = "anderson@gmail.com",
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.FirstName.ShouldBe("GlenTeacher");
        }

        [Fact]
        public async Task Should_Not_Create_A_Teacher_Without_FirstName()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await TeacherAppService.CreateAsync(
                    new CreateUpdateTeacherDto
                    {
                        FirstName = "",
                        LastName = "Wizli",
                        Email = "wizli@gmail.com",
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == "FirstName"));
        }
    }
}
