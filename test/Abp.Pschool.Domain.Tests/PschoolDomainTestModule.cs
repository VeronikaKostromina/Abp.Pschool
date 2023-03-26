using Abp.Pschool.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Abp.Pschool;

[DependsOn(
    typeof(PschoolEntityFrameworkCoreTestModule)
    )]
public class PschoolDomainTestModule : AbpModule
{

}
