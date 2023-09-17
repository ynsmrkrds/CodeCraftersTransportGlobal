namespace TransportGlobalWeb.UI.Models.RequestModels.UserContextRequestModels.User
{
    public class UpdatePasswordRequestModel
    {
        public string CurrentPassword { get; set; } = string.Empty;

        public string NewPassword { get; set; } = string.Empty;
    }
}
