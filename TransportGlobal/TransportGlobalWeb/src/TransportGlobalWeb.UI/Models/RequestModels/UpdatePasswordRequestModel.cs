namespace TransportGlobalWeb.UI.Models.RequestModels
{
    public class UpdatePasswordRequestModel
    {
        public string CurrentPassword { get; set; } = string.Empty;

        public string NewPassword { get; set; } = string.Empty;
    }
}
