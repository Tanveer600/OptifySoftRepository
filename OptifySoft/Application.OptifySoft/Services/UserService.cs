using Application.OptifySoft.Common.Models;
using Application.OptifySoft.Common.Settings;
using Application.OptifySoft.DTO.UserDto;
using Application.OptifySoft.Interface;
using Domain.OptifySoft.Entities;
using Domain.OptifySoft.Interface;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OptifySoft.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashPasswordRepository _hashPasswordRepository;
        private readonly JwtSettings _jwtSettings;

        public UserService(IUserRepository userRepository, IHashPasswordRepository hashPasswordRepository,JwtSettings jwtSettings)
        {
            _userRepository = userRepository;
            _hashPasswordRepository = hashPasswordRepository;
            _jwtSettings = jwtSettings;
        }

        public async Task<ResponseDataModel<int>> CreateUserAsync( CreateUserDto dto, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                RoleId = dto.RoleId,
                TenantId = dto.TenantId,
                BranchId = dto.BranchId,
                Status = dto.Status,
                PasswordHash = _hashPasswordRepository.HashPassword(dto.Password)
            };

            await _userRepository.AddAsync(user, cancellationToken);

            // ✅ DB generated UserId
            return ResponseDataModel<int>
                .SuccessResponse(user.UserId, "User created successfully");
        }

        public async Task<ResponseDataModel<UpdateUserDto>> UpdateUserAsync(int id, UpdateUserDto dto, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(id, cancellationToken);
            if (user == null)
                return ResponseDataModel<UpdateUserDto>.FailureResponse("User not found");

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.RoleId = dto.RoleId;
            user.BranchId = dto.BranchId;
            user.Status = dto.Status;

            if (!string.IsNullOrEmpty(dto.Password))
            {
                user.PasswordHash = _hashPasswordRepository.HashPassword(dto.Password); // hashing
            }

            await _userRepository.UpdateAsync(user, cancellationToken);
            return ResponseDataModel<UpdateUserDto>.SuccessResponse(dto, "User updated successfully");
        }

       

        public async Task<ResponseDataModel<List<CreateUserDto>>> GetUsersAsync(CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(cancellationToken);

            var dtoList = users.Select(u => new CreateUserDto
            {
                Name = u.Name,
                Email = u.Email,
                RoleId = u.RoleId,
                BranchId = u.BranchId,
                TenantId = u.TenantId,
                Status = u.Status
            }).ToList();

            return ResponseDataModel<List<CreateUserDto>>.SuccessResponse(dtoList);
        }

        public async Task<ResponseDataModel<CreateUserDto>> GetUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(id, cancellationToken);
            if (user == null) return ResponseDataModel<CreateUserDto>.FailureResponse("User not found");

            var dto = new CreateUserDto
            {
                Name = user.Name,
                Email = user.Email,
                RoleId = user.RoleId,
                BranchId = user.BranchId,
                TenantId = user.TenantId,
                Status = user.Status
            };

            return ResponseDataModel<CreateUserDto>.SuccessResponse(dto);
        }
        // UserService
        // ✅ Updated LoginUser with JWT
        public async Task<ResponseDataModel<CreateUserDto>> LoginUser(LoginUserDto dto, CancellationToken cancellationToken)
        {
            var user = await _userRepository.LoginUser(dto.Username, dto.Password, cancellationToken);
            if (user == null)
                return ResponseDataModel<CreateUserDto>.FailureResponse("Invalid credentials");

            // Map user info to DTO
            var userDto = new CreateUserDto
            {
                Name = user.Name,
                Email = user.Email,
                RoleId = user.RoleId,
                BranchId = user.BranchId,
                TenantId = user.TenantId,
                Status = user.Status
            };

            // Generate JWT token
            var token = GenerateJwtToken(user);

            // You can include token in a custom DTO or return as a claim inside user DTO
            userDto.Token = token; // Add Token property in CreateUserDto

            return ResponseDataModel<CreateUserDto>.SuccessResponse(userDto, "Login successful");
        }

        // Helper method to generate JWT token
        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()) // for role-based authorization
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<ResponseDataModel<bool>> DeleteUserAsync(int id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(id, cancellationToken);
            if (user == null) return ResponseDataModel<bool>.FailureResponse("User not found");

            await _userRepository.DeleteAsync(user, cancellationToken);
            return ResponseDataModel<bool>.SuccessResponse(true, "User deleted successfully");
        }
    }

}
