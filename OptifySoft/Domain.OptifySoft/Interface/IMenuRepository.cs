using Domain.OptifySoft.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Interface
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<Menu>> GetByRoleAsync(int roleId, CancellationToken cancellationToken);
        Task<Menu?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(Menu menu, CancellationToken cancellationToken);
        Task UpdateAsync(Menu menu, CancellationToken cancellationToken);
        Task DeleteAsync(Menu menu,CancellationToken cancellationToken);
    }
}
