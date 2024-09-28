using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdoption.Api.Services;
using PetAdoption.Shared.Dtos;
using System.Security.Claims;

namespace PetAdoption.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserPetService _userPetService;
        private readonly IPetService _petService;
        private readonly IAuthService _authService;

        public UserController(IUserPetService userPetService, IPetService petService, IAuthService authService)
        {
            _userPetService = userPetService;
            _petService = petService;
            _authService = authService;
        }


        private int UserId => Convert.ToInt32(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

        // api/user/adopt/1
        [HttpPost("adopt/{petId:int}")]
        public async Task<ApiRespone> AdotPetAsyns(int petId) =>
            await _userPetService.AdotPetAsyns(UserId, petId);

        // api/user/adoptions
        [HttpGet("adoptions")]
        public async Task<ApiRespone<PetListDto[]>> GetUserAdoptionAsyns() =>
            await _userPetService.GetUserAdoptionAsyns(UserId);

        // api/user/favorites
        [HttpGet("favorites")]
        public async Task<ApiRespone<PetListDto[]>> GetUserFavoritesAsyns() =>
            await _userPetService.GetUserFavoritesAsyns(UserId);

        // api/user/favorites/1
        [HttpPost("favorites/{petId:int}")]
        public async Task<ApiRespone> ToggleFavoritesAsync(int petId) =>
            await _userPetService.ToggleFavoritesAsync(UserId, petId);


        //api/user/view-pet-details/5
        [HttpGet("view-pet-details/{petId:int}")]
        public async Task<ApiRespone<PetDetailDto>> GetPetDetailsAsync(int petId) =>
            await _petService.GetPetDetailsAsync(petId, UserId);

        [HttpPost("change-password")]
        public async Task<ApiRespone> ChangePassword(SingeValue<string> newPassword) =>
            await _authService.ChangePasswordAsync(UserId, newPassword.Value);

    }
}
