using Application.OptifySoft.Common.Models;
using Application.OptifySoft.Interface;
using Domain.OptifySoft.Entities;
using Domain.OptifySoft.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptifySoft.Services
{
    public class TenantSettingService:ITenantSettingService
    {
        private readonly ITenantSettingInterface _tenantsettingRepository;

        public TenantSettingService(ITenantSettingInterface tenantsettingRepository)
        {
            _tenantsettingRepository = tenantsettingRepository;
        }

        // GET ALL
        public async Task<ResponseDataModel<List<TenantSetting>>> GetTenantSettingsAsync(CancellationToken cancellationToken)
        {
            var TenantSettings = await _tenantsettingRepository.GetAllAsync(cancellationToken);

            var dtoList = TenantSettings.Select(m => new TenantSetting
            {
                TenantId = m.TenantId,
                Key = m.Key,
                Value = m.Value,
                Description = m.Description,
            }).ToList();

            return ResponseDataModel<List<TenantSetting>>.SuccessResponse(dtoList);
        }

        // GET BY ID
        public async Task<ResponseDataModel<TenantSetting>> GetTenantSettingByIdAsync(int id, CancellationToken cancellationToken)
        {
            var TenantSetting = await _tenantsettingRepository.GetByIdAsync(id, cancellationToken);
            if (TenantSetting == null)
                return ResponseDataModel<TenantSetting>.FailureResponse("TenantSetting not found");

            var dto = new TenantSetting
            {
                TenantId = TenantSetting.TenantId,
                Value = TenantSetting.Value,
                Key = TenantSetting.Key,
                Description = TenantSetting.Description,

            };

            return ResponseDataModel<TenantSetting>.SuccessResponse(dto);
        }

        // CREATE
        public async Task<ResponseDataModel<TenantSetting>> CreateTenantSettingAsync(TenantSetting dto, CancellationToken cancellationToken)
        {
            var TenantSetting = new TenantSetting
            {
                TenantId = dto.TenantId,
                Value = dto.Value,
                Key = dto.Key,
                Description = dto.Description,

            };

            await _tenantsettingRepository.AddAsync(TenantSetting, cancellationToken);

            dto.TenantId = TenantSetting.TenantId;

            return ResponseDataModel<TenantSetting>.SuccessResponse(dto, "TenantSetting created successfully");
        }

        // UPDATE
        public async Task<ResponseDataModel<TenantSetting>> UpdateTenantSettingAsync(int id, TenantSetting dto, CancellationToken cancellationToken)
        {
            var TenantSetting = await _tenantsettingRepository.GetByIdAsync(id, cancellationToken);
            if (TenantSetting == null)
                return ResponseDataModel<TenantSetting>.FailureResponse("TenantSetting not found");

            TenantSetting.Key = dto.Key;
            TenantSetting.Value = dto.Value;
            TenantSetting.Description = dto.Description;



            await _tenantsettingRepository.UpdateAsync(TenantSetting, cancellationToken);

            var updatedDto = new TenantSetting
            {
                TenantId = TenantSetting.TenantId,
                Value = TenantSetting.Value,
                Key = TenantSetting.Key,
                Description = TenantSetting.Description,

            };

            return ResponseDataModel<TenantSetting>.SuccessResponse(updatedDto, "TenantSetting updated successfully");
        }

        // DELETE
        public async Task<ResponseDataModel<bool>> DeleteTenantSettingAsync(int id, CancellationToken cancellationToken)
        {
            var TenantSetting = await _tenantsettingRepository.GetByIdAsync(id, cancellationToken);
            if (TenantSetting == null)
                return ResponseDataModel<bool>.FailureResponse("TenantSetting not found");

            await _tenantsettingRepository.DeleteAsync(TenantSetting, cancellationToken);

            return ResponseDataModel<bool>.SuccessResponse(true, "TenantSetting deleted successfully");
        }
    }
}
