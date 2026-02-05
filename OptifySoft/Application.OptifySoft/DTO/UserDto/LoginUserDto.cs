using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptifySoft.DTO.UserDto
{
    public class LoginUserDto
    {
        public string Username { get; set; } = null!; // ya Email
        public string Password { get; set; } = null!;
    }
}
