﻿using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Abp.Pschool.Students
{
    public class StudentAppService :
        CrudAppService<
            Student, //The Student entity
            StudentDto, //Used to show students
            Guid, //Primary key of the student entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateStudentDto>, //Used to create/update a student
        IStudentAppService //implement the IStudentAppService
    {
        public StudentAppService(IRepository<Student, Guid> repository) : base(repository)
        {
        }
    }
}