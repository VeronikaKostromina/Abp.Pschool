using System.Threading.Tasks;

namespace Abp.Pschool.Data;

public interface IPschoolDbSchemaMigrator
{
    Task MigrateAsync();
}
