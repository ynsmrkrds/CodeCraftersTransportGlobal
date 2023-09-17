using Newtonsoft.Json;
using TransportGlobalWeb.UI.Enums;

namespace TransportGlobalWeb.UI.Helpers
{
    public static class CookieHelper
    {
        private static IHttpContextAccessor? _httpContextAccessor;

        public static void Initialize(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static bool SetCookie(CookieKey cookieKey, string value, DateTime? expireDate = null)
        {
            CookieOptions option = new()
            {
                IsEssential = true,
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            if (expireDate != null)
            {
                option.Expires = expireDate;
            }

            try
            {
                _httpContextAccessor!.HttpContext!.Response.Cookies.Append(cookieKey.Value(), value, option);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string? GetCookie(CookieKey cookieKey)
        {
            return _httpContextAccessor?.HttpContext?.Request.Cookies[cookieKey.Value()];
        }

        public static bool RemoveCookie(CookieKey cookieKey)
        {
            try
            {
                _httpContextAccessor!.HttpContext!.Response.Cookies.Delete(cookieKey.Value());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsCookieExists(CookieKey cookieKey)
        {
            return _httpContextAccessor?.HttpContext?.Request.Cookies.ContainsKey(cookieKey.Value()) == true;
        }
    }
}
