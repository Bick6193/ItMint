﻿using System.Collections.Generic;
using Domain.Permissions;
using JetBrains.Annotations;

namespace Domain.User
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class RolePermissionDetails : DomainBase, IChangeType
    {
        public Permission Permission => GetPermission();

        public bool Read { get; set; }

        public bool Write { get; set; }

        public bool Create { get; set; }

        public bool Delete { get; set; }

        public bool Execute { get; set; }

        public PermissionObject Object { get; set; }

        public ChangeType ChangeType { get; set; }

        public List<ChangesDetails> Changes { get; set; }

        private Permission GetPermission()
        {
            Permission result = Permission.None;
            result = result | (Read ? Permission.Read : 0);
            result = result | (Write ? Permission.Write : 0);
            result = result | (Create ? Permission.Create : 0);
            result = result | (Delete ? Permission.Remove : 0);
            result = result | (Execute ? Permission.Execute : 0);
            return result;
        }
    }
}