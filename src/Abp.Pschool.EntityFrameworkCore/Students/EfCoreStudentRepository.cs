using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Pschool.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Pschool.Students
{
    public class EfCoreStudentRepository : EfCoreRepository<PschoolDbContext, Student, Guid>,
        IStudentRepository
    {
        public EfCoreStudentRepository(IDbContextProvider<PschoolDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Student>> GetListAsync<T>(
            int skipCount,
            int maxResultCount,
            string sorting,
            Expression<Func<Student, bool>> func)
        {
            var dbSet = await GetDbSetAsync();

            return dbSet
                .Where(func)
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToList();
        }
    }
}
