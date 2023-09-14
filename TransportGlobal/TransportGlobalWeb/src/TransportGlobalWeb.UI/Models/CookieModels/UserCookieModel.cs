using TransportGlobalWeb.UI.Enums.UserContextEnums;

namespace TransportGlobalWeb.UI.Models.CookieModels
{
    public class UserCookieModel : BaseCookieModel
    {
        public string Token { get; set; }

        public UserType UserType { get; set; }

        public UserCookieModel(string token, UserType userType)
        {
            Token = token;
            UserType = userType;
        }
    }
}
