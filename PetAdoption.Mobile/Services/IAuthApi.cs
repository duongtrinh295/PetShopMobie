using PetAdoption.Shared.Dtos;


namespace PetAdoption.Mobile.Services
{
    public interface IAuthApi
    {
        [Post("/api/auth/login")]
        Task<ApiRespone<AuthResponseDto>> LoginAsync(LoginRequestDto dto); 

        [Post("/api/auth/register")]
        Task<ApiRespone<AuthResponseDto>> RegisterAsync( RegisterRequestDto dto);
    }

}
