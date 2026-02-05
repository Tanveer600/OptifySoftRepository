using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptifySoft.DTO.UserDto
{
    public class ChangePasswordDto
    {
        public int UserId { get; set; }

        public string CurrentPassword { get; set; } = null!;

        public string NewPassword { get; set; } = null!;
    }
}
