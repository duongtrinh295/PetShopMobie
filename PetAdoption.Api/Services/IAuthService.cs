using PetAdoption.Shared.Dtos;

namespace PetAdoption.Api.Services
{
    public interface IAuthService
    {
        Task<ApiRespone<AuthResponseDto>> LoginAsyns(LoginRequestDto dto);
        Task<ApiRespone<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto);
        Task<ApiRespone> ChangePasswordAsync(int userId, string newPassword);

    }
}