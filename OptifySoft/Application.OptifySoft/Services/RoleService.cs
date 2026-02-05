using Application.OptifySoft.Common.Models;
using Application.OptifySoft.Interface;
using Domain.OptifySoft.Entities;
using Domain.OptifySoft.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptifySoft.Services
{
    public class RoleService:IRoleService
    {
        private readonly IRoleInterface _roleInterface;
        public RoleService(IRoleInterface roleInterface)
        {
            _roleInterface = roleInterface;
        }
        // GET ALL
        public async Task<ResponseDataModel<List<Role>>> GetRolesAsync(CancellationToken cancellationToken)
        {
            var Roles = await _roleInterface.GetAllAsync(cancellationToken);

            var dtoList = Roles.Select(m => new Role
            {
                RoleId = m.RoleId,
                RoleName = m.RoleName,
                Description = m.Description,
                TenantId = m.TenantId,
            }).ToList();

            return ResponseDataModel<List<Role>>.SuccessResponse(dtoList);
        }

        // GET BY ID
        public async Task<ResponseDataModel<Role>> GetRoleByIdAsync(int id, CancellationToken cancellationToken)
        {
            var Role = await _roleInterface.GetByIdAsync(id, cancellationToken);
            if (Role == null)
                return ResponseDataModel<Role>.FailureResponse("Role not found");

            var dto = new Role
            {
                RoleId = Role.RoleId,
                RoleName = Role.RoleName,
                Description = Role.Description,
                TenantId = Role.TenantId,

            };

            return ResponseDataModel<Role>.SuccessResponse(dto);
        }

        // CREATE
        public async Task<ResponseDataModel<Role>> CreateRoleAsync(Role dto, CancellationToken cancellationToken)
        {
            var Role = new Role
            {
                RoleId = dto.RoleId,
                RoleName = dto.RoleName,
                Description = dto.Description,
                TenantId= dto.TenantId,

            };

            await _roleInterface.AddAsync(Role, cancellationToken);

            dto.RoleId = Role.RoleId;

            return ResponseDataModel<Role>.SuccessResponse(dto, "Role created successfully");
        }

        // UPDATE
        public async Task<ResponseDataModel<Role>> UpdateRoleAsync(int id, Role dto, CancellationToken cancellationToken)
        {
            var Role = await _roleInterface.GetByIdAsync(id, cancellationToken);
            if (Role == null)
                return ResponseDataModel<Role>.FailureResponse("Role not found");

            Role.RoleName = dto.RoleName;
            Role.Description = dto.Description;



            await _roleInterface.UpdateAsync(Role, cancellationToken);

            var updatedDto = new Role
            {
                RoleId = Role.RoleId,
                RoleName = Role.RoleName,
                Description = Role.Description,
                TenantId = Role.TenantId,

            };

            return ResponseDataModel<Role>.SuccessResponse(updatedDto, "Role updated successfully");
        }

        // DELETE
        public async Task<ResponseDataModel<bool>> DeleteRoleAsync(int id, CancellationToken cancellationToken)
        {
            var Role = await _roleInterface.GetByIdAsync(id, cancellationToken);
            if (Role == null)
                return ResponseDataModel<bool>.FailureResponse("Role not found");

            await _roleInterface.DeleteAsync(Role, cancellationToken);

            return ResponseDataModel<bool>.SuccessResponse(true, "Role deleted successfully");
        }
    }
}
