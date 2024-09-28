using Microsoft.EntityFrameworkCore;
using PetAdoption.Api.Data;
using PetAdoption.Api.Data.Entities;
using PetAdoption.Shared.Dtos;

namespace PetAdoption.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly TokenService _tokenService;
        private readonly PetContext _context;

        public AuthService(PetContext Context, TokenService tokenService)
        {
            _context = Context;
            _tokenService = tokenService;
        }

        public async Task<ApiRespone> ChangePasswordAsync(int userId, string newPassword)
        {
            var dbUser = await _context.Users
                .AsTracking()
                .FirstOrDefaultAsync(x => x.Id == userId);

            if(dbUser is not null)
            {
                dbUser.Password = newPassword;
                await _context.SaveChangesAsync();
                return ApiRespone.Success();
            }
            return ApiRespone.Fail("Invalid request");

        }

        public async Task<ApiRespone<AuthResponseDto>> LoginAsyns(LoginRequestDto dto)
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (dbUser is null)
                return ApiRespone<AuthResponseDto>.Fail("User does not exist");

            if (dbUser.Password != dto.Password)
                return ApiRespone<AuthResponseDto>.Fail("Incorrect password");

            var token = _tokenService.GenerateJwt(dbUser);

            return ApiRespone<AuthResponseDto>.Success(new AuthResponseDto(dbUser.Id, dbUser.Name, token));
        }

        public async Task<ApiRespone<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (existingUser is not null)
                return ApiRespone<AuthResponseDto>.Fail("Email already exists");

            // Create a new User object with the provided details
            var dbUser = new User
            {
                Email = dto.Email,
                Salt = "OK",
                Hash = "OK",
                Name = dto.Name,
                Password = dto.Password
            };

            await _context.Users.AddAsync(dbUser);
            await _context.SaveChangesAsync();

            var token = _tokenService.GenerateJwt(dbUser);

            return ApiRespone<AuthResponseDto>.Success(new AuthResponseDto(dbUser.Id, dbUser.Name, token));

        }


    }
}
