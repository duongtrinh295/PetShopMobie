using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PetAdoption.Mobile.Models;
using PetAdoption.Mobile.Pages;

namespace PetAdoption.Mobile.ViewModels
{
    [QueryProperty(nameof(IsFirstTime), nameof(IsFirstTime))]
    public partial class LoginRegisterViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isRegistrationMode;

        [ObservableProperty]
        private LoginRegisterModel _model;

        [ObservableProperty]
        private bool? _isFirstTime;

        [ObservableProperty]
        private bool _isBusy;

        public void Initialize()
        {
            if (IsFirstTime.HasValue && IsFirstTime.Value)
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
                var toast = CommunityToolkit.Maui.Alerts.Toast.Make("All fields are mandatory", ToastDuration.Short);
                await toast.Show();
                return;
            }
            IsBusy = true;
            await Task.Delay(1000);
            await SkipForNow();
            IsBusy = false;
        }


    }
}
