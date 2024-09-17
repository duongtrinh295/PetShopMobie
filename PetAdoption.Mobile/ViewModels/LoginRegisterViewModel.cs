namespace PetAdoption.Mobile.ViewModels
{
    [QueryProperty(nameof(IsFirstTime), nameof(IsFirstTime))]
    public partial class LoginRegisterViewModel : BaseViewModel
    {
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
            await Task.Delay(1000);
            await SkipForNow();
            IsBusy = false;
        }


    }
}
