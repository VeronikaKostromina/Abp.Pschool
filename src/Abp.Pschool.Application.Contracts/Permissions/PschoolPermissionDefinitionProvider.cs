using Abp.Pschool.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Abp.Pschool.Permissions;

public class PschoolPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PschoolPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(PschoolPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PschoolResource>(name);
    }
}
