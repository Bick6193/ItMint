namespace Domain.Permissions
{
    public enum PermissionObject
    {
        Default = 0,
        User = 1,
        Employee = 2,
        AccountManager = 3,

        AutomaticActionFunction = 500,
        ExportFunction = 501,
    }
}