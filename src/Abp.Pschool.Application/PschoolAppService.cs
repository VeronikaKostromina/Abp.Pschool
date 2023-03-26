using System;
using System.Collections.Generic;
using System.Text;
using Abp.Pschool.Localization;
using Volo.Abp.Application.Services;

namespace Abp.Pschool;

/* Inherit your application services from this class.
 */
public abstract class PschoolAppService : ApplicationService
{
    protected PschoolAppService()
    {
        LocalizationResource = typeof(PschoolResource);
    }
}
