﻿
namespace PetAdoption.Mobile.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly IPetsApi _petsApi;
        public readonly CommonService _commonService;
        private readonly AuthService _authService;

        public HomeViewModel(IPetsApi petsApi, CommonService commonService, AuthService authService)
        {
            _petsApi = petsApi;
            _commonService = commonService;
            _authService = authService;
            _commonService.LoginStatusChanged += OnLoginStatusChanged;
            SetUserInfo();
        }

        private void OnLoginStatusChanged(object sender, EventArgs e) => SetUserInfo();

        private void SetUserInfo()
        {
            if (_authService.IsLoggedIn)
            {
                var userInfo = _authService.GetUser();
                UserName = userInfo.Name;
                _commonService.SetToken(userInfo.Token);
            }
            else
            {
                UserName = "Stranger";
            }
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
