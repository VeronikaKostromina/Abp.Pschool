namespace Abp.Pschool.Permissions;

public static class PschoolPermissions
{
    public const string GroupName = "Pschool";

    public static class Students
    {
        public const string Default = GroupName + ".Students";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Teachers
    {
        public const string Default = GroupName + ".Teachers";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

}
