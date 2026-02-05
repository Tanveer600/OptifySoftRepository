using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptifySoft.DTO.UserDto
{
    public class CreateUserDto
    {
        
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;   // plain password

        public int RoleId { get; set; }
       // public int UserId { get; set; }

        public int TenantId { get; set; }
        // ✅ New property to return JWT
        public string Token { get; set; } = null!;
        public int BranchId { get; set; }

        public string Status { get; set; } = "Active";
    }
}
