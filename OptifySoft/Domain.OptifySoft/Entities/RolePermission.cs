using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
   
   
        public class RolePermission
        {
            public int RolePermissionId { get; set; }

            public int RoleId { get; set; }
            public int TenantId { get; set; }
            public int PermissionId { get; set; }

            public bool IsActive { get; set; } = true;

            // Navigation (optional in Domain, OK to keep simple)
            public Role? Role { get; set; }
            public Permission? Permission { get; set; }
        }
    

}
