using Application.OptifySoft.Common.Interfaces;
using Domain.OptifySoft.Entities;
using Domain.OptifySoft.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.OptifySoft.Repository
{
    public class TenantSettingRepository:ITenantSettingInterface
    {
        private readonly IApplicationDbContext _context;

        public TenantSettingRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TenantSetting>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.TenantSettings.ToListAsync(cancellationToken);
        }

        public async Task<List<TenantSetting>> GetByTenantSettingAsync(int Id, CancellationToken cancellationToken)
        {
            return await _context.TenantSettings.Where(x => x.TenantId == Id).ToListAsync(cancellationToken);
        }

        public async Task<TenantSetting?> GetByIdAsync(int id, CancellationToken cancellation)
        {
            return await _context.TenantSettings.FindAsync(id, cancellation);
        }

        public async Task AddAsync(TenantSetting menu, CancellationToken cancellationToken)
        {
            _context.TenantSettings.Add(menu);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TenantSetting menu, CancellationToken cancellationToken = default)
        {
            var list = await _context.TenantSettings.FirstOrDefaultAsync(x => x.TenantId == menu.TenantId, cancellationToken);
            if (list != null)
            {
                list.Value = menu.Value;
                list.Key = menu.Key;
                list.Description = menu.Description;

                _context.TenantSettings.Update(list);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(TenantSetting menu, CancellationToken cancellationToken = default)
        {
            var list = await _context.TenantSettings.FirstOrDefaultAsync(x => x.TenantId == menu.TenantId, cancellationToken);
            if (list != null)
            {
                _context.TenantSettings.Remove(list);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

    }
}
