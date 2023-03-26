using Abp.Pschool.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.Pschool.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PschoolController : AbpControllerBase
{
    protected PschoolController()
    {
        LocalizationResource = typeof(PschoolResource);
    }
}
