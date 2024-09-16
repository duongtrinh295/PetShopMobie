using Microsoft.AspNetCore.Mvc;
using PetAdoption.Api.Services;
using PetAdoption.Shared.Dtos;

namespace PetAdoption.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : Controller
    {
        private readonly IPetService _petService;
        public PetsController(IPetService petService) 
        {
            _petService = petService;
        }

        //api/pét
        [HttpGet("")]
        public async Task<ApiRespone<PetListDto[]>> GetAllPetsAsync() =>
            await _petService.GetAllPetsAsync();

        //api/pets/new/5
        [HttpGet("/new/{count:int}")]
        public async Task<ApiRespone<PetListDto[]>> GetNewlyAddedPetsAsyns(int count) =>
            await _petService.GetNewlyAddedPetsAsyns(count);

        //api/pets/5
        [HttpGet("{petId:int}")]
        public async Task<ApiRespone<PetDetailDto>> GetPetDetailsAsync(int petId) =>
            await _petService.GetPetDetailsAsync(petId);

        //api/popular/new/5
        [HttpGet("/popular/{count:int}")]
        public async Task<ApiRespone<PetListDto[]>> GetPopularPetsAsyns(int count) =>
            await _petService.GetPopularPetsAsyns(count);

        //api/pets/random/5
        [HttpGet("/random/{count:int}")]
        public async Task<ApiRespone<PetListDto[]>> GetRandomPetsAsyns(int count) =>
            await _petService.GetRandomPetsAsyns(count);

    }
}
