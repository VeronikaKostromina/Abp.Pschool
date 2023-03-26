using Volo.Abp.Settings;

namespace Abp.Pschool.Settings;

public class PschoolSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(PschoolSettings.MySetting1));
    }
}
