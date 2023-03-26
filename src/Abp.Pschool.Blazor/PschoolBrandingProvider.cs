using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Abp.Pschool.Blazor;

[Dependency(ReplaceServices = true)]
public class PschoolBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Pschool";
}
