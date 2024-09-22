using PetAdoption.Shared.Dtos;


namespace PetAdoption.Mobile.Services
{
    public class AuthService
    {
        private readonly CommonService _commonService;
        private readonly IAuthApi _authApi;

        public AuthService(CommonService commonService, IAuthApi authApi)
        {
            _commonService = commonService;
            _authApi = authApi;
        }

        public async Task<bool> LoginRegisterAsync(LoginRegisterModel model)
        {
            ApiRespone<AuthResponseDto> apiResponse = null;
            try
            {
                if (model.IsNewUser)
                {
                    // Register API
                    apiResponse = await _authApi.RegisterAsync(new RegisterRequestDto
                    {
                        Email = model.Email,
                        Name = model.Name,
                        Password = model.Password,
                    });
                }
                else
                {
                    // Login API
                    apiResponse = await _authApi.LoginAsync(new LoginRequestDto
                    {
                        Email = model.Email,
                        Password = model.Password,
                    });
                }

            }
            catch (Refit.ApiException ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return false;
            }

            if (!apiResponse.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", apiResponse.Message, "OK");
                return false;
            }
            var user = new LoggedInUser(apiResponse.data.UserId, apiResponse.data.Name, apiResponse.data.Token);
            SetUser(user);
            _commonService.SetToken(apiResponse.data.Token);

            return true;

        }

        private void SetUser(LoggedInUser user) =>
            Preferences.Default.Set(UiConstants.UserInfo, user.ToJson());


        public async Task Logout()
        {
            _commonService.SetToken(null);
            Preferences.Default.Remove(UiConstants.UserInfo);
        }

        public LoggedInUser GetUser()
        {
            var userJson = Preferences.Default.Get(UiConstants.UserInfo, string.Empty);
            return LoggedInUser.LoadFromJson(userJson);

        }

        public bool IsLoggedIn => Preferences.Default.ContainsKey(UiConstants.UserInfo);
    }
}
