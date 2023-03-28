using Volo.Abp.Application.Dtos;

namespace Abp.Pschool.Teachers
{
    public class GetTeacherListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
