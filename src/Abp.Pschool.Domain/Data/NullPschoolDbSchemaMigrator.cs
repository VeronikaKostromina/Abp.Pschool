using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Abp.Pschool.Data;

/* This is used if database provider does't define
 * IPschoolDbSchemaMigrator implementation.
 */
public class NullPschoolDbSchemaMigrator : IPschoolDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
