using Abp.Pschool.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Abp.Pschool.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PschoolEntityFrameworkCoreModule),
    typeof(PschoolApplicationContractsModule)
    )]
public class PschoolDbMigratorModule : AbpModule
{

}
