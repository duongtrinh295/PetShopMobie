using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoption.Mobile.ViewModels
{
    public partial class FavoritesViewModel : BaseViewModel
    {
        private readonly IUserApi _userApi;
        private readonly AuthService _authService;

        [ObservableProperty]
        public ObservableCollection<PetSlim> _pets = new();

        public FavoritesViewModel(IUserApi userApi, AuthService authService)
        {
            _userApi = userApi;
            _authService = authService;
            
        }

        public async Task InitializeAsync()
        {
            if (!_authService.IsLoggedIn)
            {
                Pets.Clear();
                await ShowToastAsync("You need to be logged in to load your favorite pets");
                return;
            }

            try
            {
                IsBusy = true;
                var apiResponse = await _userApi.GetUserFavoritesAsyns();
                if (apiResponse.IsSuccess && apiResponse.data != null)
                {
                    // Xóa danh sách cũ trước khi thêm mới
                    Pets.Clear();

                    // Thêm dữ liệu từ API vào danh sách Pets
                    foreach (var pet in apiResponse.data)
                    {
                        Pets.Add(new PetSlim
                        {
                            Id = pet.Id,
                            Image = pet.Image,
                            IsFavorite = true, // Mặc định tất cả là yêu thích
                            Name = pet.Name
                        });
                    }
                }
                else
                {
                    await ShowAlertAsync("Error in fetching pets", apiResponse.Message);
                }
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Error fetching pets", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task ToggleFavoriteAsync(int petId)
        {
            try
            {
                var pet = Pets.FirstOrDefault(x => x.Id == petId);
                if (pet is not null)
                {
                    IsBusy = true;
                    pet.IsFavorite = !pet.IsFavorite; // Thay đổi trạng thái yêu thích
                    var apiResponse = await _userApi.ToggleFavoritesAsync(petId);

                    if (apiResponse.IsSuccess)
                    {
                        if (!pet.IsFavorite)
                        {
                            Pets.Remove(pet); // Xóa pet khỏi danh sách nếu không còn yêu thích
                        }
                    }
                    else
                    {
                        await ShowAlertAsync("Error in toggling favorite", apiResponse.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Error toggling favorite", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
