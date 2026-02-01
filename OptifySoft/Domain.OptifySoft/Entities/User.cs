using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int RoleId { get; set; }
        public int TenantId { get; set; }
        public int BranchId { get; set; }
        public string? PasswordHash { get; set; }
        public string? Status { get; set; }
    }
}
