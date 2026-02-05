using Application.OptifySoft.Common.Interfaces;
using Domain.OptifySoft.Entities;
using Domain.OptifySoft.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.OptifySoft.Repository
{
    public class RoleRepository:IRoleInterface
    {
        private readonly IApplicationDbContext _context;
        public RoleRepository(IApplicationDbContext context)
        {
            _context=context;
        }

        public async Task<List<Role>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Roles.ToListAsync(cancellationToken);
        }

        public async Task<List<Role>> GetByRoleAsync(int Id, CancellationToken cancellationToken)
        {
            return await _context.Roles.Where(x => x.RoleId == Id).ToListAsync(cancellationToken);
        }

        public async Task<Role?> GetByIdAsync(int id, CancellationToken cancellation)
        {
            return await _context.Roles.FindAsync(id, cancellation);
        }

        public async Task AddAsync(Role role, CancellationToken cancellationToken)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Role role, CancellationToken cancellationToken = default)
        {
            var list = await _context.Roles.FirstOrDefaultAsync(x => x.RoleId == role.RoleId, cancellationToken);
            if (list != null)
            {
                list.RoleName = role.RoleName;
                list.Description = role.Description;
                list.TenantId = role.TenantId;


                _context.Roles.Update(list);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(Role role, CancellationToken cancellationToken = default)
        {
            var list = await _context.Roles.FirstOrDefaultAsync(x => x.RoleId == role.RoleId, cancellationToken);
            if (list != null)
            {
                _context.Roles.Remove(list);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

    }
}
