using System;
using System.Threading.Tasks;
using Abp.Pschool.Students;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Abp.Pschool.Teachers
{
    public interface ITeacherAppService : IApplicationService
    {
        Task<TeacherDto> GetAsync(Guid id);

        Task<PagedResultDto<TeacherDto>> GetListAsync(GetTeacherListDto input);

        Task<TeacherDto> CreateAsync(CreateTeacherDto input);

        Task UpdateAsync(Guid id, UpdateTeacherDto input);

        Task DeleteAsync(Guid id);
        Task<PagedResultDto<StudentDto>> GetStudentListForCurrentTeacher(Guid id, GetStudentListDto input);
    }
}
