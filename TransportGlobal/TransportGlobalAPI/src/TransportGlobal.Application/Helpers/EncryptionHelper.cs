using System.Security.Cryptography;
using System.Text;

namespace TransportGlobal.Application.Helpers
{
    public static class EncryptionHelper
    {
        private static readonly string SecretKey = "TransportGlobal_2023_PRIVATE_KEY";

        public static string Encrypt(string value)
        {
            using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(SecretKey));

            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            byte[] hashBytes = hmac.ComputeHash(valueBytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
