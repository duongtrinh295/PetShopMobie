
namespace PetAdoption.Mobile.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly IPetsApi _petsApi;
        public HomeViewModel(IPetsApi petsApi)
        {
            _petsApi = petsApi;
        }

        [ObservableProperty]
        private IEnumerable<PetListDto> _newlyAdded = Enumerable.Empty<PetListDto>();

        [ObservableProperty]
        private IEnumerable<PetListDto> _poplar = Enumerable.Empty<PetListDto>();

        [ObservableProperty]
        private IEnumerable<PetListDto> _random = Enumerable.Empty<PetListDto>();

        [ObservableProperty]
        private string _userName = "Stranger";
        private bool _isInitialized;

        public async Task InitializeAsync()
        {
            if (_isInitialized)
                return;

            IsBusy = true;
            try
            {
                await Task.Delay(100);
                var newLyAddedTask = _petsApi.GetNewlyAddedPetsAsyns(5);
                var popularPetsTask = _petsApi.GetPopularPetsAsyns(10);
                var randomPetsTask = _petsApi.GetRandomPetsAsyns(6);

                NewlyAdded = (await newLyAddedTask).data;
                Poplar = (await popularPetsTask).data;
                Random = (await randomPetsTask).data;

                _isInitialized = true;
            }
            catch (ApiException ex)
            {
                await ShowAlertAsync("Error", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    
    }
}
