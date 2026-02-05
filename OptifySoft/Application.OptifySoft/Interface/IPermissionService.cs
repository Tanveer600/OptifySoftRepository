using Application.OptifySoft.Common.Models;
using Application.OptifySoft.DTO;
using Domain.OptifySoft.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptifySoft.Interface
{
    public interface IPermissionService
    {
        Task<ResponseDataModel<List<Permission>>> GetPermissionsAsync(CancellationToken cancellationToken);
        Task<ResponseDataModel<Permission>> GetPermissionByIdAsync(int id, CancellationToken cancellationToken);
        Task<ResponseDataModel<Permission>> CreatePermissionAsync(Permission dto, CancellationToken cancellationToken);
        Task<ResponseDataModel<Permission>> UpdatePermissionAsync(int id, Permission dto, CancellationToken cancellationToken);
        Task<ResponseDataModel<bool>> DeletePermissionAsync(int id, CancellationToken cancellationToken);
    }
}
