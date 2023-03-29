using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Pschool.Permissions;
using Abp.Pschool.Teachers;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
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
        private readonly ITeacherRepository teacherRepository;
        public StudentAppService(IRepository<Student, Guid> repository, ITeacherRepository teacherRepository)
            : base(repository)
        {
            GetPolicyName = PschoolPermissions.Students.Default;
            GetListPolicyName = PschoolPermissions.Students.Default;
            CreatePolicyName = PschoolPermissions.Students.Create;
            UpdatePolicyName = PschoolPermissions.Students.Edit;
            DeletePolicyName = PschoolPermissions.Students.Delete;
            this.teacherRepository = teacherRepository;
        }

        public async Task<ListResultDto<TeacherLookupDto>> GetAuthorLookupAsync()
        {
            var teachers = await teacherRepository.GetListAsync();

            return new ListResultDto<TeacherLookupDto>(
                ObjectMapper.Map<List<Teacher>, List<TeacherLookupDto>>(teachers)
            );
        }

        public override async Task<StudentDto> GetAsync(Guid id)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from student in queryable
                        join teacher in await teacherRepository.GetQueryableAsync()
                            on student.TeacherId equals teacher.Id
                        where student.Id == id
                        select new { student, teacher };

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Student), id);
            }

            var studentDto = ObjectMapper.Map<Student, StudentDto>(queryResult.student);
            studentDto.TeacherFullName = $"{queryResult.teacher.FirstName} {queryResult.teacher.LastName}";

            return studentDto;
        }

        public override async Task<PagedResultDto<StudentDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from student in queryable
                        join teacher in await teacherRepository.GetQueryableAsync() on student.TeacherId equals teacher.Id
                        select new { student, teacher };

            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var studentDtos = queryResult.Select(x =>
            {
                var studentDto = ObjectMapper.Map<Student, StudentDto>(x.student);
                studentDto.TeacherFullName = $"{x.teacher.FirstName} {x.teacher.LastName}";

                return studentDto;
            }).ToList();

            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<StudentDto>(
                totalCount,
                studentDtos
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"student.{nameof(Student.LastName)}";
            }

            if (sorting.Contains("TeacherFullName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "TeacherFullName",
                    "teacher.LastName",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"student.{sorting}";
        }
    }
}
