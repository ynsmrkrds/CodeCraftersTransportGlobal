namespace TransportGlobalWeb.UI.Models.ResponseModels
{
    public class LoginResponseModel : BaseResponseModel
    {
        public string Token { get; set; }

        public LoginResponseModel(string token)
        {
            Token = token;
        }
    }
}
