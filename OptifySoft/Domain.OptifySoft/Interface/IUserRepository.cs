using Domain.OptifySoft.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken);      
        Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(User User, CancellationToken cancellationToken);
        Task UpdateAsync(User User, CancellationToken cancellationToken);
        Task DeleteAsync(User User, CancellationToken cancellationToken);
        Task<User> LoginUser(string username,string password, CancellationToken cancellationToken);
    }
}
