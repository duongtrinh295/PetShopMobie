using PetAdoption.Mobile.Pages;

namespace PetAdoption.Mobile
{
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (Preferences.Default.ContainsKey(UiConstants.OnboardingShow))
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            else
                await Shell.Current.GoToAsync($"//{nameof(OnboardingPage)}");
        }
    }
}