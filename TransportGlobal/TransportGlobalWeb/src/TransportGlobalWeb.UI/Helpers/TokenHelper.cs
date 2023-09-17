using System.IdentityModel.Tokens.Jwt;
using TransportGlobalWeb.UI.Enums.UserContextEnums;

namespace TransportGlobalWeb.UI.Helpers
{
    public static class TokenHelper
    {
        public static DateTime GetTokenExpiryDate(string token)
        {
            JwtSecurityTokenHandler handler = new();
            return handler.ReadJwtToken(token).ValidTo;
        }

        public static UserType GetUserType(string token)
        {
            JwtSecurityTokenHandler handler = new();

            JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(token);
            string userType = jwtSecurityToken.Claims.First(x => x.Type == "user_type").Value;

            return Enum.Parse<UserType>(userType);
        }
    }
}
