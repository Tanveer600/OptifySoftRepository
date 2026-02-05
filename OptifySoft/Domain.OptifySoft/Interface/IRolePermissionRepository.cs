using Domain.OptifySoft.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Interface
{
    public interface IRolePermissionRepository
    {
        Task<List<RolePermission>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<RolePermission>> GetByRolePermissionAsync(int Id, CancellationToken cancellationToken);
        Task<RolePermission?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(RolePermission model, CancellationToken cancellationToken);
        Task UpdateAsync(RolePermission model, CancellationToken cancellationToken);
        Task DeleteAsync(RolePermission model, CancellationToken cancellationToken);
    }
}
