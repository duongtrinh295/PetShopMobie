﻿namespace PetAdoption.Mobile.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        private readonly AuthService _authService;
        private readonly CommonService _commonService;

        public ProfileViewModel(AuthService authService, CommonService commonService)
        {
            _authService = authService;
            _commonService = commonService;
            _commonService.LoginStatusChanged += OnLoginStatusChanged;
            SetUserInfo();
        }
        private void OnLoginStatusChanged(object sender, EventArgs e) => SetUserInfo();
       
        private void SetUserInfo()
        {
            if (_authService.IsLoggedIn)
            {
                var userInfo = _authService.GetUser();
                UserName = userInfo.Name;
                IsLoggedIn = true;
            }
            else
            {
                UserName = "Not logged In";
                IsLoggedIn = false;
            }
        }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Initials))]
        private string _userName = "Not logged In";

        [ObservableProperty]
        private bool _isLoggedIn;

        public string Initials
        {
            get
            {
                var parts = UserName.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (parts.Length == 1)
                {
                    return UserName.Length == 1
                        ? UserName
                        : UserName[..2]; // Nếu username chỉ có 1 từ, lấy 2 ký tự đầu tiên.
                }

                // Nếu username có nhiều hơn một từ, trả về ký tự đầu của mỗi từ.
                return $"{parts[0][0]}{parts[1][0]}";
            }
        }

        [RelayCommand]
        private async Task LoginLogotAsync()
        {
            if (!IsLoggedIn)
                await GoToAsync($"//{nameof(LoginRegisterPage)}");
            else
            {
                _authService.Logout();
                await GoToAsync($"//{nameof(HomePage)}");
            }
                
        }
    }
}
