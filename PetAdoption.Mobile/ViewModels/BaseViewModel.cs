namespace PetAdoption.Mobile.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;


        [RelayCommand]
        private async Task GotoDetailsPage(int petId) =>
            await GoToAsync($"{nameof(DetailsPage)}?{nameof(DetailViewModel.PetId)}={petId}");


        protected async Task GoToAsync(ShellNavigationState state) =>
            await Shell.Current.GoToAsync(state);

        protected async Task GoToAsync(ShellNavigationState state, bool animate) =>
            await Shell.Current.GoToAsync(state, animate);

        protected async Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters) =>
            await Shell.Current.GoToAsync(state, parameters);

        protected async Task GoToAsync(ShellNavigationState state, bool animate, IDictionary<string, object> parameters) =>
            await Shell.Current.GoToAsync(state, animate, parameters);

        public async Task ShowToastAsync(string message) =>
            await CommunityToolkit.Maui.Alerts.Toast.Make(message).Show();

        protected async Task ShowAlertAsync(string title, string message, string buttonText = "OK") =>
            await App.Current.MainPage.DisplayAlert(title, message, buttonText);

        protected async Task ShowConfirmAsync(string title, string message, string okButtonText, string cancelButtionText) =>
            await App.Current.MainPage.DisplayAlert(title, message, okButtonText, cancelButtionText);
    }
}
