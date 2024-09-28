namespace PetAdoption.Mobile.ViewModels
{
    public partial class MyAdoptionsViewModel :BaseViewModel
    {
        private readonly AuthService _authService;
        private readonly IUserApi _userApi;

        public MyAdoptionsViewModel(AuthService authService, IUserApi userApi)
        {
            _authService = authService;
            _userApi = userApi;
        }

        [ObservableProperty]
        private IEnumerable<PetListDto> _myAdoptions = Enumerable.Empty<PetListDto>();

        public async Task InitializeAsync()
        {
            if (!_authService.IsLoggedIn)
            {
                await ShowToastAsync("You need to be logged in to load your favorite pets");
                return;
            }

            try
            {
                IsBusy = true;
                await Task.Delay(100);
                var apiResponese = await _userApi.GetUserAdoptionAsyns();
                if (apiResponese.IsSuccess)
                {
                    MyAdoptions = apiResponese.data;
                }
                else
                {
                    await ShowAlertAsync("Error", apiResponese.Message);
                }
            }
            catch (Exception ex)
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
