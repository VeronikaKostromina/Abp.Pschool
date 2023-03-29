using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Abp.Pschool.Students
{
    public interface IStudentRepository : IRepository<Student, Guid>
    {
        Task<List<Student>> GetListAsync<T>(
            int skipCount,
            int maxResultCount,
            string sorting,
            Expression<Func<Student, bool>> func);
    }
}
