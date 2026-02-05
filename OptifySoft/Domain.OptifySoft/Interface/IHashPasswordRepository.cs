using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Interface
{
    public interface IHashPasswordRepository
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string providedPassword);
    }
}
