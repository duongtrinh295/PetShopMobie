using PetAdoption.Shared.Dtos;
using Refit;

namespace PetAdoption.Mobile.Services
{
    public interface IPetsApi
    {
        [Get("/api/pets")]
        Task<ApiRespone<PetListDto[]>> GetAllPetsAsync();

        [Get("/api/pets/new/{count}")]
        Task<ApiRespone<PetListDto[]>> GetNewlyAddedPetsAsyns(int count);

        [Get("/api/pets/{petId}")]
        Task<ApiRespone<PetDetailDto>> GetPetDetailsAsync(int petId);

        [Get("/api/pets/popular/{count}")]
        Task<ApiRespone<PetListDto[]>> GetPopularPetsAsyns(int count);

        [Get("/api/pets/random/{count}")]
        Task<ApiRespone<PetListDto[]>> GetRandomPetsAsyns(int count);
    }
}
