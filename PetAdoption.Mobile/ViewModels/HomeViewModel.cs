
namespace PetAdoption.Mobile.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        [ObservableProperty]
        private IEnumerable<PetListDto> _newlyAdded = Enumerable.Empty<PetListDto>();
    }
}
