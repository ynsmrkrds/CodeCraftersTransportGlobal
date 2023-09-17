using TransportGlobalWeb.UI.Enums.UserContextEnums;

namespace TransportGlobalWeb.UI.Models.RequestModels.UserContextRequestModels.User
{
    public class RegisterRequestModel
    {
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public UserType Type { get; set; } = UserType.Customer;
    }
}
