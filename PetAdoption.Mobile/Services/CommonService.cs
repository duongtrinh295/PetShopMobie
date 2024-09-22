namespace PetAdoption.Mobile.Services
{
    public class CommonService
    {
        public string? Token { get; set; }

        public void SetToken(string? token) => Token = token;
    }
}
