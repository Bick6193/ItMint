using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Permissions;
using JetBrains.Annotations;

namespace Domain.User
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class ApplicationUserLogin : DomainBase
    {
        public ApplicationUserLogin()
        {
            Roles = new List<RoleDetails>();
        }

        public string Login { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    
        public string Password { get; set; }

        public UserType UserType { get; set; }

        public List<RoleDetails> Roles { get; set; }

        public bool Active { get; set; }

        public string FullName { get; set; }

        public bool ChangePasswordOnFirstLogon { get; set; }


        public List<RolePermissionDetails> GetPermissions()
        {
            return Roles.SelectMany(x => x.RolePermissions).ToList();
        }

        public bool IsAdministrative()
        {
            return Roles.Aggregate(false, (prev, role) => role.IsAdministrative || prev);
        }

        public bool CanEdit()
        {
            return Roles.Aggregate(false, (prev, role) => role.CanEdit || prev);
        }

        public Dictionary<int, int> GetPermissionsMap()
        {
            var permissionMap = new Dictionary<int, int>();

            if (IsAdministrative() && CanEdit())
            {
                var values = Enum.GetValues(typeof(PermissionObject)).Cast<PermissionObject>().ToList();
                values.ForEach(permissionObject =>
                {
                    //todo: handle null value
                    var name = Enum.GetName(typeof(PermissionObject), permissionObject);

                    permissionMap[(int) permissionObject] = (int) (name.EndsWith("Function") ? Permission.Execute : Permission.Full);
                });
            }
            else
            {
                if (IsAdministrative())
                {
                    var values = Enum.GetValues(typeof(PermissionObject)).Cast<PermissionObject>().ToList();
                    values.ForEach(permissionObject =>
                    {
                        var name = Enum.GetName(typeof(PermissionObject), permissionObject);

                        if (!name.EndsWith("Function"))
                        {
                            permissionMap[(int) permissionObject] = (int) Permission.Read;
                        }
                    });
                }

                var permissions = GetPermissions();

                permissions.ForEach(rolePermission =>
                {
                    var permission = rolePermission.Permission;

                    var permissionObject = (int) rolePermission.Object;

                    if (permissionMap.ContainsKey(permissionObject))
                    {
                        permission = permission | rolePermission.Permission;
                    }

                    permissionMap[permissionObject] = (int) permission;
                });
            }
            return permissionMap;
        }
    }
}