using Domain.OptifySoft.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Interface
{
    public interface ITenantSettingInterface
    {
        Task<List<TenantSetting>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<TenantSetting>> GetByTenantSettingAsync(int Id, CancellationToken cancellationToken);
        Task<TenantSetting?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(TenantSetting model, CancellationToken cancellationToken);
        Task UpdateAsync(TenantSetting model, CancellationToken cancellationToken);
        Task DeleteAsync(TenantSetting model, CancellationToken cancellationToken);
    }
}
