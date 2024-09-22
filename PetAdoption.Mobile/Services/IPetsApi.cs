using PetAdoption.Shared.Dtos;
using Refit;

namespace PetAdoption.Mobile.Services
{
    public interface IPetsApi
    {
        [Get("/api/pets")]
        Task<ApiRespone<PetListDto[]>> GetAllPetsAsync();

        [Get("/api/pets/new/{count:int}")]
        Task<ApiRespone<PetListDto[]>> GetNewlyAddedPetsAsyns(int count);

        [Get("/api/pets/{petId:int}")]
        Task<ApiRespone<PetDetailDto>> GetPetDetailsAsync(int petId);

        [Get("/api/pets/popular/{count:int}")]
        Task<ApiRespone<PetListDto[]>> GetPopularPetsAsyns(int count);

        [Get("/api/pets/random/{count:int}")]
        Task<ApiRespone<PetListDto[]>> GetRandomPetsAsyns(int count);
    }
}
