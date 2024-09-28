using PetAdoption.Shared.Enumerations;
using Refit;

namespace PetAdoption.Mobile.ViewModels
{
    [QueryProperty(nameof(PetId), nameof(PetId))]
    public partial class DetailViewModel : BaseViewModel
    {
        private readonly IPetsApi _petsApi;
        private readonly AuthService _authService;
        private readonly IUserApi _userApi;

        public DetailViewModel(IPetsApi petsApi, AuthService authService, IUserApi userApi)
        {
            _petsApi = petsApi;
            _authService = authService;
            _userApi = userApi;
        }

        [ObservableProperty]
        private int _petId = new();

        [ObservableProperty]
        private Pet _petDetail = new();

        async partial void OnPetIdChanged(int petId)
        {
            // fetch the pet detail from the Api
            IsBusy = true;
            try
            {
                await Task.Delay(100);
                var apiResponse = _authService.IsLoggedIn
                    ? await _userApi.GetPetDetailsAsync(petId)
                    : await _petsApi.GetPetDetailsAsync(petId);
                if (apiResponse.IsSuccess)
                {

                    var petDto = apiResponse.data;
                    PetDetail = new Pet
                    {
                        AdoptionStatus = petDto.AdoptionStatus,
                        Age = petDto.Age,
                        Breed = petDto.Breed,
                        Description = petDto.Description,
                        GenderDisplay = petDto.GenderDisplay,
                        GenderImage = petDto.GenderImage,
                        Id = petDto.Id,
                        Image = petDto.Image,
                        IsFavorite = petDto.IsFavorite,
                        Name = petDto.Name,
                        Price = petDto.Price
                    };
                }
                else
                    await ShowAlertAsync("Error in fetching pet details", apiResponse.Message);
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Error in fetching pet details", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }


        [RelayCommand]
        private async Task GoBack() => await GoToAsync("..");

        [RelayCommand]
        private async Task ToggleFavorite()
        {
            if (!_authService.IsLoggedIn)
            {
                await ShowToastAsync("You need to be logged in to mark this pet as favorite");
                return;
            }
            PetDetail.IsFavorite = !PetDetail.IsFavorite;

            try
            {
                IsBusy = true;
                await _userApi.ToggleFavoritesAsync(PetId);
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy= false;
                //Revert
                PetDetail.IsFavorite = !PetDetail.IsFavorite;
                await ShowAlertAsync("Error in toggling favorite status", ex.Message);
            }
        }

        [RelayCommand]
        public async Task AdoptPetAsync()
        {
            if (!_authService.IsLoggedIn)
            {
                await ShowToastAsync("You need to be logged in to load your favorite pets okkokok");
                return;
            }
            IsBusy = true;
            try
            {
                var apiResponse = await _userApi.AdoptPetAsyns(PetId);
                if (apiResponse.IsSuccess)
                {
                    // Cập nhật trạng thái nhận nuôi
                    PetDetail.AdoptionStatus = AdoptionStatus.Adopted;
                    await GoToAsync(nameof(AdoptionSuccessPage));
                }
                else
                {
                    await ShowAlertAsync("Error in adoption", apiResponse.Message);
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Error in adoption", ex.Message);
            }
            finally
            {
                IsBusy = false; // Đảm bảo cờ IsBusy được đặt lại, dù có lỗi hay không
            }
        }
    }
}
