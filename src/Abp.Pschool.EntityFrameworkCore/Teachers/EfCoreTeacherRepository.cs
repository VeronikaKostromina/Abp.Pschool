using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Pschool.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Pschool.Teachers
{
    public class EfCoreTeacherRepository : EfCoreRepository<PschoolDbContext, Teacher, Guid>,
        ITeacherRepository
    {
        public EfCoreTeacherRepository(IDbContextProvider<PschoolDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Teacher?> FindByFullNameAsync(string firstName, string lastName)
        {
            DbSet<Teacher> dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName);
        }

        public async Task<List<Teacher>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    x => x.FirstName!.Contains(filter) || x.LastName!.Contains(filter)
                )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
