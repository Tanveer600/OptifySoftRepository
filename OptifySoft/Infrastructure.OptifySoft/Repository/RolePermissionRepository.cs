using Application.OptifySoft.Common.Interfaces;
using Domain.OptifySoft.Entities;
using Domain.OptifySoft.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.OptifySoft.Repository
{
    public class RolePermissionRepository:IRolePermissionRepository
    {
        private readonly IApplicationDbContext _context;
        public RolePermissionRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RolePermission>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.RolePermissions.ToListAsync(cancellationToken);
        }

        public async Task<List<RolePermission>> GetByRolePermissionAsync(int Id, CancellationToken cancellationToken)
        {
            return await _context.RolePermissions.Where(x => x.RolePermissionId == Id).ToListAsync(cancellationToken);
        }

        public async Task<RolePermission?> GetByIdAsync(int id, CancellationToken cancellation)
        {
            return await _context.RolePermissions.FindAsync(id, cancellation);
        }

        public async Task AddAsync(RolePermission RolePermission, CancellationToken cancellationToken)
        {
            _context.RolePermissions.Add(RolePermission);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(RolePermission RolePermission, CancellationToken cancellationToken = default)
        {
            var list = await _context.RolePermissions.FirstOrDefaultAsync(x => x.RolePermissionId == RolePermission.RolePermissionId, cancellationToken);
            if (list != null)
            {
                list.PermissionId = RolePermission.PermissionId;
                list.RoleId = RolePermission.RoleId;
                list.IsActive = RolePermission.IsActive;
                list.TenantId = RolePermission.TenantId;


                _context.RolePermissions.Update(list);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(RolePermission RolePermission, CancellationToken cancellationToken = default)
        {
            var list = await _context.RolePermissions.FirstOrDefaultAsync(x => x.RolePermissionId == RolePermission.RolePermissionId, cancellationToken);
            if (list != null)
            {
                _context.RolePermissions.Remove(list);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

    }
}
