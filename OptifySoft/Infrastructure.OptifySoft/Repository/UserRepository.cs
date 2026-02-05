using Application.OptifySoft.Common.Interfaces;
using Domain.OptifySoft.Entities;
using Domain.OptifySoft.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.OptifySoft.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IHashPasswordRepository _hashPasswordRepository;

        public UserRepository(IApplicationDbContext applicationDbContext, IHashPasswordRepository hashPasswordRepository)
        {
            _applicationDbContext = applicationDbContext;
            _hashPasswordRepository = hashPasswordRepository;
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await _applicationDbContext.Users.AddAsync(user, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var existingUser = await _applicationDbContext.Users
                .FirstOrDefaultAsync(x => x.UserId == user.UserId, cancellationToken);

            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.RoleId = user.RoleId;
                existingUser.BranchId = user.BranchId;
                existingUser.Status = user.Status;
                existingUser.PasswordHash = user.PasswordHash;

                _applicationDbContext.Users.Update(existingUser);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(User user, CancellationToken cancellationToken)
        {
            var existingUser = await _applicationDbContext.Users
                .FirstOrDefaultAsync(x => x.UserId == user.UserId, cancellationToken);

            if (existingUser != null)
            {
                _applicationDbContext.Users.Remove(existingUser);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Users.ToListAsync(cancellationToken);
        }

        public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
        }

        // ✅ Corrected: matches interface signature
        public async Task<User> LoginUser(string username, string password, CancellationToken cancellationToken)
        {
            var normalizedUsername = username.Trim().ToLower();
            var user = await _applicationDbContext.Users
                .FirstOrDefaultAsync(x => x.Name.ToLower() == normalizedUsername, cancellationToken);


            if (user == null)
                return null!; // null allowed

            bool isValid = _hashPasswordRepository.VerifyPassword(user.PasswordHash!, password);

            return isValid ? user : null!;
        }
    }

}
