namespace TransportGlobalWeb.UI.Models.ResponseModels.UserResponseModels.User
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
