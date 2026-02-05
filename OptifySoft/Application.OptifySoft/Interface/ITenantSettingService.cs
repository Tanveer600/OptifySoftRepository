using Application.OptifySoft.Common.Models;
using Domain.OptifySoft.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptifySoft.Interface
{
    public interface ITenantSettingService
    {
        Task<ResponseDataModel<List<TenantSetting>>> GetTenantSettingsAsync(CancellationToken cancellationToken);
        Task<ResponseDataModel<TenantSetting>> GetTenantSettingByIdAsync(int id, CancellationToken cancellationToken);
        Task<ResponseDataModel<TenantSetting>> CreateTenantSettingAsync(TenantSetting dto, CancellationToken cancellationToken);
        Task<ResponseDataModel<TenantSetting>> UpdateTenantSettingAsync(int id, TenantSetting dto, CancellationToken cancellationToken);
        Task<ResponseDataModel<bool>> DeleteTenantSettingAsync(int id, CancellationToken cancellationToken);
    }
}
