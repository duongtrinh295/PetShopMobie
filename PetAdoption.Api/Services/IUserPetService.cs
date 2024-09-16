using PetAdoption.Shared.Dtos;

namespace PetAdoption.Api.Services
{
    public interface IUserPetService
    {
        Task<ApiRespone> AdotPetAsyns(int userId, int petId);
        Task<ApiRespone<PetListDto[]>> GetUserAdoptionAsyns(int userId);
        Task<ApiRespone<PetListDto[]>> GetUserFavoritesAsyns(int userId);
        Task<ApiRespone> ToggleFavoritesAsync(int userId, int petId);
    }
}