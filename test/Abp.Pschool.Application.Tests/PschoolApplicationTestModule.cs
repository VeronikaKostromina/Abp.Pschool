using Volo.Abp.Modularity;

namespace Abp.Pschool;

[DependsOn(
    typeof(PschoolApplicationModule),
    typeof(PschoolDomainTestModule)
    )]
public class PschoolApplicationTestModule : AbpModule
{

}
