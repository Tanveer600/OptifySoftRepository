using Domain.OptifySoft.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Interface
{
    public interface IRoleInterface
    {
        Task<List<Role>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<Role>> GetByRoleAsync(int Id, CancellationToken cancellationToken);
        Task<Role?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(Role model, CancellationToken cancellationToken);
        Task UpdateAsync(Role model, CancellationToken cancellationToken);
        Task DeleteAsync(Role model, CancellationToken cancellationToken);
    }
}
