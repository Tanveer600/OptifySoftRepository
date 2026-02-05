using Application.OptifySoft.DTO;
using Application.OptifySoft.Common.Models;
using Domain.OptifySoft.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OptifySoft.Interface
{
    public interface IMenuService
    {
        Task<ResponseDataModel<List<MenuDto>>> GetMenusAsync(CancellationToken cancellationToken);
        Task<ResponseDataModel<MenuDto>> GetMenuByIdAsync(int id, CancellationToken cancellationToken);
        Task<ResponseDataModel<MenuDto>> CreateMenuAsync(MenuDto dto, CancellationToken cancellationToken);
        Task<ResponseDataModel<MenuDto>> UpdateMenuAsync(int id, UpdateMenuDto dto, CancellationToken cancellationToken);
        Task<ResponseDataModel<bool>> DeleteMenuAsync(int id, CancellationToken cancellationToken);


    }
}
