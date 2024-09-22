using PetAdoption.Shared.Dtos;

namespace PetAdoption.Mobile.Services
{
    [Headers("Authorization : Bearer")]
    public interface IUserApi
    {
        [Post("/api/user/adopt/{petId}")]
        Task<ApiRespone> AdotPetAsyns(int userId, int petId);

        [Get("/api/user/adoptions")]
        Task<ApiRespone<PetListDto[]>> GetUserAdoptionAsyns(int userId);

        [Get("/api/user/favorites")]
        Task <ApiRespone<PetListDto[]>> GetUserFavoritesAsyns(int userId);

        [Post("/api/user/favorites/{petId}")]
        Task<ApiRespone> ToggleFavoritesAsync(int userId, int petId);
    }
}
