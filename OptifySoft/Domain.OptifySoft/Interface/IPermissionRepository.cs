using Domain.OptifySoft.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Interface
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<Permission>> GetByPermissionAsync(int Id, CancellationToken cancellationToken);
        Task<Permission?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(Permission model, CancellationToken cancellationToken);
        Task UpdateAsync(Permission model, CancellationToken cancellationToken);
        Task DeleteAsync(Permission model, CancellationToken cancellationToken);
    }
}
