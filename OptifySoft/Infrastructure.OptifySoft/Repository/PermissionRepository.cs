using Application.OptifySoft.Common.Interfaces;
using Domain.OptifySoft.Entities;
using Domain.OptifySoft.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.OptifySoft.Repository
{
    public class PermissionRepository:IPermissionRepository
    {
        
            private readonly IApplicationDbContext _context;

            public PermissionRepository(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Permission>> GetAllAsync(CancellationToken cancellationToken)
            {
                return await _context.Permissions.ToListAsync(cancellationToken);
            }

            public async Task<List<Permission>> GetByPermissionAsync(int Id, CancellationToken cancellationToken)
            {
            return await _context.Permissions.Where(x=>x.PermissionId==Id).ToListAsync(cancellationToken);               
            }

            public async Task<Permission?> GetByIdAsync(int id, CancellationToken cancellation)
            {
                return await _context.Permissions.FindAsync(id, cancellation);
            }

            public async Task AddAsync(Permission menu, CancellationToken cancellationToken)
            {
                _context.Permissions.Add(menu);
                await _context.SaveChangesAsync(cancellationToken);
            }

            public async Task UpdateAsync(Permission menu, CancellationToken cancellationToken = default)
            {
                var list = await _context.Permissions.FirstOrDefaultAsync(x => x.PermissionId == menu.PermissionId, cancellationToken);
                if (list != null)
                {
                    list.PermissionName = menu.PermissionName;
                    list.Description = menu.Description;
                   

                    _context.Permissions.Update(list);
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }

            public async Task DeleteAsync(Permission menu, CancellationToken cancellationToken = default)
            {
                var list = await _context.Permissions.FirstOrDefaultAsync(x => x.PermissionId == menu.PermissionId, cancellationToken);
                if (list != null)
                {
                    _context.Permissions.Remove(list);
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }


        }
    }

