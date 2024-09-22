namespace PetAdoption.Mobile.ViewModels
{
    [QueryProperty(nameof(PetId), nameof(PetId))]
    public partial class DetailViewModel : BaseViewModel
    {
        private readonly IPetsApi _petsApi;
        public DetailViewModel(IPetsApi petsApi)
        {
            _petsApi = petsApi;
        }

        [ObservableProperty]
        private int _petId;

        [ObservableProperty]
        private PetDetailDto _petDetail = new();

        async partial void OnPetIdChanged(int petId)
        {
            // fetch the pet detail from the Api
            IsBusy = true;
            try
            {
                var apiResponse = await _petsApi.GetPetDetailsAsync(petId);
                if (apiResponse.IsSuccess)
                    PetDetail = apiResponse.data;
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
    }
}
