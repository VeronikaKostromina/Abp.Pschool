using Abp.Pschool.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Abp.Pschool.Permissions;

public class PschoolPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var pschoolGroup = context.AddGroup(PschoolPermissions.GroupName, L("Permission:Pschool"));

        var studentPermission = pschoolGroup.AddPermission(PschoolPermissions.Students.Default, L("Permission:Students"));
        studentPermission.AddChild(PschoolPermissions.Students.Create, L("Permission:Students.Create"));
        studentPermission.AddChild(PschoolPermissions.Students.Edit, L("Permission:Students.Edit"));
        studentPermission.AddChild(PschoolPermissions.Students.Delete, L("Permission:Students.Delete"));

        var teacherPermission = pschoolGroup.AddPermission(PschoolPermissions.Teachers.Default, L("Permission:Teachers"));
        teacherPermission.AddChild(PschoolPermissions.Teachers.Create, L("Permission:Teachers.Create"));
        teacherPermission.AddChild(PschoolPermissions.Teachers.Edit, L("Permission:Teachers.Edit"));
        teacherPermission.AddChild(PschoolPermissions.Teachers.Delete, L("Permission:Teachers.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PschoolResource>(name);
    }
}
