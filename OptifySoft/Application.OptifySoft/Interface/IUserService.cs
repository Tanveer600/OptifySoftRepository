using Application.OptifySoft.Common.Models;
using Application.OptifySoft.DTO;
using Application.OptifySoft.DTO.UserDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptifySoft.Interface
{
    public interface IUserService
    {
        Task<ResponseDataModel<List<CreateUserDto>>> GetUsersAsync(CancellationToken cancellationToken);
        Task<ResponseDataModel<CreateUserDto>> GetUserByIdAsync(int id, CancellationToken cancellationToken);
        Task<ResponseDataModel<int>> CreateUserAsync(CreateUserDto dto, CancellationToken cancellationToken);
        Task<ResponseDataModel<UpdateUserDto>> UpdateUserAsync(int id, UpdateUserDto dto, CancellationToken cancellationToken);
        Task<ResponseDataModel<bool>> DeleteUserAsync(int id, CancellationToken cancellationToken);
        Task<ResponseDataModel<CreateUserDto>> LoginUser(LoginUserDto dto, CancellationToken cancellationToken);
    }
}
