namespace PetAdoption.Mobile.Pages;

public partial class DetailsPage : ContentPage
{
    private readonly DetailViewModel _viewModel;

    public DetailsPage(DetailViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}