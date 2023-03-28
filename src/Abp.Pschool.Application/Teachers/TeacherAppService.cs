using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Pschool.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Abp.Pschool.Teachers
{
    public class TeacherAppService : PschoolAppService, ITeacherAppService
    {
        private readonly ITeacherRepository teacherRepository;
        private readonly TeacherManager teacherManager;

        public TeacherAppService(ITeacherRepository teacherRepository, TeacherManager teacherManager)
        {
            this.teacherRepository = teacherRepository;
            this.teacherManager = teacherManager;
        }

        public async Task<TeacherDto> GetAsync(Guid id)
        {
            var teacher = await teacherRepository.GetAsync(id);
            return ObjectMapper.Map<Teacher, TeacherDto>(teacher);
        }

        public async Task<PagedResultDto<TeacherDto>> GetListAsync(GetTeacherListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Teacher.LastName);
            }


            var teachers = input.Filter == null ? await teacherRepository.GetListAsync(
                    input.SkipCount,
                    input.MaxResultCount,
                    input.Sorting
                )
                    : await teacherRepository.GetListAsync(
                    input.SkipCount,
                    input.MaxResultCount,
                    input.Sorting,
                    input.Filter
                );

            var totalCount = input.Filter == null
            ? await teacherRepository.CountAsync()
            : await teacherRepository.CountAsync(
                x => x.FirstName!.Contains(input.Filter) || x.LastName!.Contains(input.Filter));

            return new PagedResultDto<TeacherDto>(
                totalCount,
                ObjectMapper.Map<List<Teacher>, List<TeacherDto>>(teachers)
            );
        }

        [Authorize(PschoolPermissions.Teachers.Create)]
        public async Task<TeacherDto> CreateAsync(CreateTeacherDto input)
        {
            var teacher = await teacherManager.CreateAsync(
                input.FirstName!,
                input.LastName!,
                input.Email!
            );

            await teacherRepository.InsertAsync(teacher);

            return ObjectMapper.Map<Teacher, TeacherDto>(teacher);
        }

        [Authorize(PschoolPermissions.Teachers.Edit)]
        public async Task UpdateAsync(Guid id, UpdateTeacherDto input)
        {
            var teacher = await teacherRepository.GetAsync(id);

            if (teacher.FirstName != input.FirstName && teacher.LastName != input.LastName)
            {
                await teacherManager.ChangeNameAsync(teacher, input.FirstName!, input.LastName!);
            }

            teacher.Email = input.Email;
            teacher.HomeAddress = input.HomeAddress;
            teacher.Phone = input.Phone;

            await teacherRepository.UpdateAsync(teacher);
        }

        [Authorize(PschoolPermissions.Teachers.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await teacherRepository.DeleteAsync(id);
        }
    }
}
