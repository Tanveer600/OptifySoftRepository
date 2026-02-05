using Application.OptifySoft.Common.Models;
using Domain.OptifySoft.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptifySoft.Interface
{
    public interface IRolePermissionService
    {
        Task<ResponseDataModel<List<RolePermission>>> GetRolePermissionsAsync(CancellationToken cancellationToken);
        Task<ResponseDataModel<RolePermission>> GetRolePermissionByIdAsync(int id, CancellationToken cancellationToken);
        Task<ResponseDataModel<RolePermission>> CreateRolePermissionAsync(RolePermission dto, CancellationToken cancellationToken);
        Task<ResponseDataModel<RolePermission>> UpdateRolePermissionAsync(int id, RolePermission dto, CancellationToken cancellationToken);
        Task<ResponseDataModel<bool>> DeleteRolePermissionAsync(int id, CancellationToken cancellationToken);
    }
}
