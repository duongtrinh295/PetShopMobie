using PetAdoption.Shared.Dtos;

namespace PetAdoption.Mobile.Services
{
    [Headers("Authorization : Bearer")]
    public interface IUserApi
    {
        [Post("/api/user/adopt/{petId}")]
        Task<ApiRespone> AdotPetAsyns(int petId);

        [Get("/api/user/adoptions")]
        Task<ApiRespone<PetListDto[]>> GetUserAdoptionAsyns();

        [Get("/api/user/favorites")]
        Task <ApiRespone<PetListDto[]>> GetUserFavoritesAsyns();

        [Post("/api/user/favorites/{petId}")]
        Task<ApiRespone> ToggleFavoritesAsync(int petId);

        //api/user/view-pet-details/5
        [Get("/api/user/view-pet-details/{petId}")]
        Task<ApiRespone<PetDetailDto>> GetPetDetailsAsync(int petId);
    }
}
