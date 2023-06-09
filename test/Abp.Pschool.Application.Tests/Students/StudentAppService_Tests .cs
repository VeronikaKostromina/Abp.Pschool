﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Pschool.Teachers;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace Abp.Pschool.Students
{
    public class StudentAppService_Tests : PschoolApplicationTestBase
    {
        private readonly IStudentAppService studentAppService;
        private readonly ITeacherAppService teacherAppService;

        public StudentAppService_Tests()
        {
            this.studentAppService = GetRequiredService<IStudentAppService>();
            this.teacherAppService = GetRequiredService<ITeacherAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Students()
        {
            //Act
            var result = await studentAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.FirstName == "Bob");
        }

        [Fact]
        public async Task Should_Create_A_Valid_Student()
        {
            //Arrange
            var teacher = (await teacherAppService.GetListAsync(new GetTeacherListDto()))
                .Items.First();

            //Act
            var result = await studentAppService.CreateAsync(
                new CreateUpdateStudentDto
                {
                    FirstName = "Glen",
                    LastName = "Anderson",
                    ClassNumber = 1,
                    Email = "anderson@gmail.com",
                    Type = StudentMarkType.Excellent,
                    TeacherId = teacher.Id
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.FirstName.ShouldBe("Glen");
        }

        [Fact]
        public async Task Should_Not_Create_A_Student_Without_FirstName()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await studentAppService.CreateAsync(
                    new CreateUpdateStudentDto
                    {
                        FirstName = "",
                        LastName = "Wizli",
                        ClassNumber = 1,
                        Email = "wizli@gmail.com",
                        Type = StudentMarkType.Excellent
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == "FirstName"));
        }
    }
}
