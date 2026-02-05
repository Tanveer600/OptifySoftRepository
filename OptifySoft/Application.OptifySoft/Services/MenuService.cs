using Application.OptifySoft.Common.Models;
using Application.OptifySoft.DTO;
using Application.OptifySoft.Interface;
using Domain.OptifySoft.Entities;
using Domain.OptifySoft.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OptifySoft.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        // GET ALL
        public async Task<ResponseDataModel<List<MenuDto>>> GetMenusAsync(CancellationToken cancellationToken)
        {
            var menus = await _menuRepository.GetAllAsync(cancellationToken);

            var dtoList = menus.Select(m => new MenuDto
            {
                Id = m.Id,
                Name = m.Name,
                Url = m.Url,
                ParentId = m.ParentId,
                Icon = m.Icon,
                OrderNo = m.OrderNo,
                IsActive = m.IsActive
            }).ToList();

            return ResponseDataModel<List<MenuDto>>.SuccessResponse(dtoList);
        }

        // GET BY ID
        public async Task<ResponseDataModel<MenuDto>> GetMenuByIdAsync(int id, CancellationToken cancellationToken)
        {
            var menu = await _menuRepository.GetByIdAsync(id, cancellationToken);
            if (menu == null)
                return ResponseDataModel<MenuDto>.FailureResponse("Menu not found");

            var dto = new MenuDto
            {
                Id = menu.Id,
                Name = menu.Name,
                Url = menu.Url,
                ParentId = menu.ParentId,
                Icon = menu.Icon,
                OrderNo = menu.OrderNo,
                IsActive = menu.IsActive
            };

            return ResponseDataModel<MenuDto>.SuccessResponse(dto);
        }

        // CREATE
        public async Task<ResponseDataModel<MenuDto>> CreateMenuAsync(MenuDto dto, CancellationToken cancellationToken)
        {
            var menu = new Menu
            {
                Name = dto.Name,
                Url = dto.Url,
                ParentId = dto.ParentId,
                Icon = dto.Icon,
                OrderNo = dto.OrderNo,
                IsActive = dto.IsActive
            };

            await _menuRepository.AddAsync(menu, cancellationToken);

            dto.Id = menu.Id;

            return ResponseDataModel<MenuDto>.SuccessResponse(dto, "Menu created successfully");
        }

        // UPDATE
        public async Task<ResponseDataModel<MenuDto>> UpdateMenuAsync(int id, UpdateMenuDto dto, CancellationToken cancellationToken)
        {
            var menu = await _menuRepository.GetByIdAsync(id, cancellationToken);
            if (menu == null)
                return ResponseDataModel<MenuDto>.FailureResponse("Menu not found");

            menu.Name = dto.Name;
            menu.Url = dto.Url;
            menu.ParentId = dto.ParentId;
            menu.Icon = dto.Icon;
            menu.OrderNo = dto.OrderNo;
            menu.IsActive = dto.IsActive;

            await _menuRepository.UpdateAsync(menu, cancellationToken);

            var updatedDto = new MenuDto
            {
                Id = menu.Id,
                Name = menu.Name,
                Url = menu.Url,
                ParentId = menu.ParentId,
                Icon = menu.Icon,
                OrderNo = menu.OrderNo,
                IsActive = menu.IsActive
            };

            return ResponseDataModel<MenuDto>.SuccessResponse(updatedDto, "Menu updated successfully");
        }

        // DELETE
        public async Task<ResponseDataModel<bool>> DeleteMenuAsync(int id, CancellationToken cancellationToken)
        {
            var menu = await _menuRepository.GetByIdAsync(id, cancellationToken);
            if (menu == null)
                return ResponseDataModel<bool>.FailureResponse("Menu not found");

            await _menuRepository.DeleteAsync(menu, cancellationToken);

            return ResponseDataModel<bool>.SuccessResponse(true, "Menu deleted successfully");
        }
    }
}
