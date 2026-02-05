using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptifySoft.DTO.UserDto
{
    public class UpdateUserDto
    {
        public int UserId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }
        public string Password { get; set; } = null!;   // plain password

        public int RoleId { get; set; }

        public int BranchId { get; set; }

        public string? Status { get; set; }
    }
}
