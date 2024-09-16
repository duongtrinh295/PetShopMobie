namespace PetAdoption.Mobile.Pages;

public partial class OnboardingPage : ContentPage
{
	public OnboardingPage()
	{
		InitializeComponent();

		Preferences.Default.Set(UiConstants.OnboardingShow, string.Empty);
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync($"//{nameof(LoginRegisterPage)}");
    }
}