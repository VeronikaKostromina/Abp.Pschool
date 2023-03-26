using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Abp.Pschool;

[Dependency(ReplaceServices = true)]
public class PschoolBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Pschool";
}
