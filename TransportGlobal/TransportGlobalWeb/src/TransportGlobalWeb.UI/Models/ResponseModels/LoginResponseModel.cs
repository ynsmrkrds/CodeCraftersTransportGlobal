namespace TransportGlobalWeb.UI.Models.ResponseModels
{
    public class LoginResponseModel : BaseResponseModel
    {
        public string Message { get; set; }

        public bool IsSuccesful { get; set; }

        public string? Token { get; set; }

        public LoginResponseModel(string message, bool isSuccesful, string? token)
        {
            Message = message;
            IsSuccesful = isSuccesful;
            Token = token;
        }
    }
}
