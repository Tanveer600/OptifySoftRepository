using Application.OptifySoft.Common.Models;
using Application.OptifySoft.DTO;
using Application.OptifySoft.Interface;
using Domain.OptifySoft.Entities;
using Domain.OptifySoft.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptifySoft.Services
{
    public class Permissionservice:IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public Permissionservice(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        // GET ALL
        public async Task<ResponseDataModel<List<Permission>>> GetPermissionsAsync(CancellationToken cancellationToken)
        {
            var permissions = await _permissionRepository.GetAllAsync(cancellationToken);

            var dtoList = permissions.Select(m => new Permission
            {
                PermissionId = m.PermissionId,
                PermissionName = m.PermissionName,
                Description = m.Description,                
            }).ToList();

            return ResponseDataModel<List<Permission>>.SuccessResponse(dtoList);
        }

        // GET BY ID
        public async Task<ResponseDataModel<Permission>> GetPermissionByIdAsync(int id, CancellationToken cancellationToken)
        {
            var permission = await _permissionRepository.GetByIdAsync(id, cancellationToken);
            if (permission == null)
                return ResponseDataModel<Permission>.FailureResponse("permission not found");

            var dto = new Permission
            {
                PermissionId = permission.PermissionId,
                PermissionName = permission.PermissionName,
                Description = permission.Description,
               
            };

            return ResponseDataModel<Permission>.SuccessResponse(dto);
        }

        // CREATE
        public async Task<ResponseDataModel<Permission>> CreatePermissionAsync(Permission dto, CancellationToken cancellationToken)
        {
            var permission = new Permission
            {
                PermissionId = dto.PermissionId,
                PermissionName = dto.PermissionName,
                Description = dto.Description,
                
            };

            await _permissionRepository.AddAsync(permission, cancellationToken);

            dto.PermissionId = permission.PermissionId;

            return ResponseDataModel<Permission>.SuccessResponse(dto, "permission created successfully");
        }

        // UPDATE
        public async Task<ResponseDataModel<Permission>> UpdatePermissionAsync(int id, Permission dto, CancellationToken cancellationToken)
        {
            var permission = await _permissionRepository.GetByIdAsync(id, cancellationToken);
            if (permission == null)
                return ResponseDataModel<Permission>.FailureResponse("permission not found");

            permission.PermissionName = dto.PermissionName;
            permission.Description = dto.Description;
            
          

            await _permissionRepository.UpdateAsync(permission, cancellationToken);

            var updatedDto = new Permission
            {
                PermissionId = permission.PermissionId,
                PermissionName = permission.PermissionName,
                Description = permission.Description,
                
            };

            return ResponseDataModel<Permission>.SuccessResponse(updatedDto, "Permission updated successfully");
        }

        // DELETE
        public async Task<ResponseDataModel<bool>> DeletePermissionAsync(int id, CancellationToken cancellationToken)
        {
            var permission = await _permissionRepository.GetByIdAsync(id, cancellationToken);
            if (permission == null)
                return ResponseDataModel<bool>.FailureResponse("Permission not found");

            await _permissionRepository.DeleteAsync(permission, cancellationToken);

            return ResponseDataModel<bool>.SuccessResponse(true, "Permission deleted successfully");
        }
    }
}
