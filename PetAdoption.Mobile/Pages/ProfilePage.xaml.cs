namespace PetAdoption.Mobile.Pages;

public partial class ProfilePage : ContentPage
{
    private readonly ProfileViewModel _viewModel;

    public ProfilePage(ProfileViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void ProfileOptionRow_Tapped(object sender, string optionText)
    {
        switch(optionText)
        {
            case "My Adoptions":
                await _viewModel.ShowToastAsync("My Adoptions tapped");
                break;
            case "Change Password":
                await _viewModel.ShowToastAsync("Change password tapped");
                break;
        }
    }
}