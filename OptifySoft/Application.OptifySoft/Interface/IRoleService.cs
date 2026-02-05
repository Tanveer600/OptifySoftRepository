using Application.OptifySoft.Common.Models;
using Domain.OptifySoft.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptifySoft.Interface
{
    public interface IRoleService
    {
        Task<ResponseDataModel<List<Role>>> GetRolesAsync(CancellationToken cancellationToken);
        Task<ResponseDataModel<Role>> GetRoleByIdAsync(int id, CancellationToken cancellationToken);
        Task<ResponseDataModel<Role>> CreateRoleAsync(Role dto, CancellationToken cancellationToken);
        Task<ResponseDataModel<Role>> UpdateRoleAsync(int id, Role dto, CancellationToken cancellationToken);
        Task<ResponseDataModel<bool>> DeleteRoleAsync(int id, CancellationToken cancellationToken);
    }
}
