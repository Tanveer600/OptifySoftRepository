using Domain.OptifySoft.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.OptifySoft.Repository
{
    public class HasPasswordRepository : IHashPasswordRepository
    {
        private readonly PasswordHasher<object> _hasher = new();
        public string HashPassword(string password)
        {
             return _hasher.HashPassword(null !, password);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _hasher.VerifyHashedPassword(null!, hashedPassword, providedPassword);

            return result == PasswordVerificationResult.Success;
        }
       
    }
}
