namespace TransportGlobalWeb.UI.Enums
{
    public enum CookieKey
    {
        User
    }

    public static class CookieKeyExtensions
    {
        public static string Value(this CookieKey cookieKey)
        {
            string value = cookieKey switch
            {
                CookieKey.User => "User",
                _ => throw new NotImplementedException(),
            };

            return $"{value}Cookie";
        }
    }
}
