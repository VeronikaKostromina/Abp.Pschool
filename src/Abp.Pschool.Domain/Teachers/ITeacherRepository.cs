using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Abp.Pschool.Teachers
{
    public interface ITeacherRepository : IRepository<Teacher, Guid>
    {
        Task<Teacher> FindByLastNameAsync(string lastName);

        Task<List<Teacher>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
