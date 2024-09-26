using PetAdoption.Shared.Dtos;

namespace PetAdoption.Api.Services
{
    public interface IPetService
    {
        Task<ApiRespone<PetListDto[]>> GetAllPetsAsync();
        Task<ApiRespone<PetListDto[]>> GetNewlyAddedPetsAsyns(int count);
        Task<ApiRespone<PetDetailDto>> GetPetDetailsAsync(int petId, int userId =0);
        Task<ApiRespone<PetListDto[]>> GetPopularPetsAsyns(int count);
        Task<ApiRespone<PetListDto[]>> GetRandomPetsAsyns(int count);
    }
}