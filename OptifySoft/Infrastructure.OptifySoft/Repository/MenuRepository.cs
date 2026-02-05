using Application.OptifySoft.Common.Interfaces;
using Domain.OptifySoft.Entities;
using Domain.OptifySoft.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.OptifySoft.Repository
{
    public class MenuRepository:IMenuRepository
    {
        private readonly IApplicationDbContext _context;

        public MenuRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Menu>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Menus
                .Where(x => x.IsActive)
                .OrderBy(x => x.OrderNo)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Menu>> GetByRoleAsync(int roleId,CancellationToken cancellationToken)
        {
            return await (
                from m in _context.Menus
                join mp in _context.MenuPermissions on m.Id equals mp.MenuID
                join rp in _context.RolePermissions on mp.PermissionID equals rp.PermissionId
                where rp.RoleId == roleId
                && m.IsActive
                select m
            ).Distinct().ToListAsync(cancellationToken);
        }

        public async Task<Menu?> GetByIdAsync(int id,CancellationToken cancellation)
        {
            return await _context.Menus.FindAsync(id,cancellation);
        }

        public async Task AddAsync(Menu menu,CancellationToken cancellationToken)
        {
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Menu menu,CancellationToken cancellationToken=default)
        {
            var list =await _context.Menus.FirstOrDefaultAsync(x => x.Id == menu.Id, cancellationToken);
            if(list !=null)
            {
                list.OrderNo = menu.OrderNo;
                list.Url= menu.Url;
                list.ParentId = menu.ParentId;
                list.Icon= menu.Icon;
                list.IsActive= menu.IsActive;
                list.Name= menu.Name;

                _context.Menus.Update(list);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(Menu menu,CancellationToken cancellationToken=default)
        {
            var list=await _context.Menus.FirstOrDefaultAsync(x=>x.Id==menu.Id,cancellationToken);
            if(list!=null)
            {
                _context.Menus.Remove(list);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

       
    }
}
