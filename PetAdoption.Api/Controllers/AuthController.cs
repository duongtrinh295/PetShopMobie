using Microsoft.AspNetCore.Mvc;
using PetAdoption.Api.Services;
using PetAdoption.Shared.Dtos;

namespace PetAdoption.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
       private readonly IAuthService _authService;
       public AuthController(IAuthService authService)  
       {
            _authService = authService;
       }

        [HttpPost("Login")]
        public async Task<ApiRespone<AuthResponseDto>> Login(LoginRequestDto loginRequest) =>
            await _authService.LoginAsyns(loginRequest);


        [HttpPost("register")]
        public async Task<ApiRespone<AuthResponseDto>> Register(RegisterRequestDto registerRequest) =>
            await _authService.RegisterAsync(registerRequest);


    }
}
