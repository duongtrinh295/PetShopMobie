namespace PetAdoption.Mobile.ViewModels
{
    [QueryProperty(nameof(IsFirstTime), nameof(IsFirstTime))]
    public partial class LoginRegisterViewModel : BaseViewModel
    {
        private readonly AuthService _authService;
        public LoginRegisterViewModel(AuthService authService)
        {
            _authService = authService;
        }
        [ObservableProperty]
        private bool _isRegistrationMode;

        [ObservableProperty]
        private LoginRegisterModel _model = new();

        [ObservableProperty]
        private bool _isFirstTime;

        partial void OnIsFirstTimeChanging(bool value)
        {
            if (value)
                IsRegistrationMode = true;
        }

        [RelayCommand]
        private void ToggleMode() => IsRegistrationMode = !IsRegistrationMode;

        [RelayCommand]
        private async Task SkipForNow() =>
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");

        [RelayCommand]

        private async Task Submit()
        {
            if (!Model.Validate(IsRegistrationMode))
            {
                var toast = ShowToastAsync("All fields are mandatory");
                return;
            }
            IsBusy = true;
            // Make api call to Login/regiter user

            var status = await _authService.LoginRegisterAsync(Model);

            if(status)
                await SkipForNow();


            IsBusy = false;
        }


    }
}
