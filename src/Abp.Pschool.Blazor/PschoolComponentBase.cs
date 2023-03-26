using Abp.Pschool.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Abp.Pschool.Blazor;

public abstract class PschoolComponentBase : AbpComponentBase
{
    protected PschoolComponentBase()
    {
        LocalizationResource = typeof(PschoolResource);
    }
}
