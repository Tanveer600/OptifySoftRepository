using Application.OptifySoft.Common.Models;
using Application.OptifySoft.Interface;
using Domain.OptifySoft.Entities;
using Domain.OptifySoft.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptifySoft.Services
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRolePermissionRepository  _rolePermissionRepository;
        public RolePermissionService(IRolePermissionRepository rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
        }
        public async Task<ResponseDataModel<RolePermission>> CreateRolePermissionAsync(RolePermission dto, CancellationToken cancellationToken)
        {
             await _rolePermissionRepository.AddAsync(dto, cancellationToken);
            return ResponseDataModel<RolePermission>.SuccessResponse(dto,"data created successfully");
        }

        public async Task<ResponseDataModel<bool>> DeleteRolePermissionAsync(int id, CancellationToken cancellationToken)
        {
            var updatelist = await _rolePermissionRepository.GetByIdAsync(id, cancellationToken);
            if (updatelist == null)
                return ResponseDataModel<bool>.FailureResponse("not deleted");

            await _rolePermissionRepository.DeleteAsync(updatelist, cancellationToken);
            return ResponseDataModel<bool>.SuccessResponse(true, "data deleted successfully");
        }

        public async Task<ResponseDataModel<RolePermission>> GetRolePermissionByIdAsync(int id, CancellationToken cancellationToken)
        {
            var permission = await _rolePermissionRepository.GetByIdAsync(id, cancellationToken);
            if (permission == null)
                return ResponseDataModel<RolePermission>.FailureResponse("role permission not found");

            var dto = new RolePermission
            {
                PermissionId = permission.PermissionId,
                RoleId = permission.RoleId,
                RolePermissionId = permission.RolePermissionId,
                IsActive = permission.IsActive,

            };

            return ResponseDataModel<RolePermission>.SuccessResponse(dto);
        }

        public async Task<ResponseDataModel<List<RolePermission>>> GetRolePermissionsAsync(CancellationToken cancellationToken)
        {
            var permissions = await _rolePermissionRepository.GetAllAsync(cancellationToken);

            var dtoList = permissions.Select(m => new RolePermission
            {
                PermissionId = m.PermissionId,
                RoleId = m.RoleId,
                TenantId = m.TenantId,
                IsActive = m.IsActive,
            }).ToList();

            return ResponseDataModel<List<RolePermission>>.SuccessResponse(dtoList);
        }

        public async Task<ResponseDataModel<RolePermission>> UpdateRolePermissionAsync(int id, RolePermission dto, CancellationToken cancellationToken)
        {

            var updatelist = await _rolePermissionRepository.GetByIdAsync(id, cancellationToken);
            if(updatelist == null)
                return  ResponseDataModel<RolePermission>.FailureResponse("not updated");

            updatelist.TenantId = dto.TenantId;
            updatelist.IsActive = dto.IsActive;
            updatelist.PermissionId = dto.PermissionId;
            updatelist.RolePermissionId = dto.RolePermissionId; 
            updatelist.RoleId = dto.RoleId; 

            await _rolePermissionRepository.UpdateAsync(updatelist, cancellationToken);
            var dtolist = new RolePermission
            {
                PermissionId = dto.PermissionId,
                RoleId = dto.RoleId,
                TenantId = dto.TenantId,
                IsActive = dto.IsActive,
                RolePermissionId = dto.RolePermissionId,
            };
            return ResponseDataModel<RolePermission>.SuccessResponse(dtolist, "data updated successfully");
        }
    }
}
