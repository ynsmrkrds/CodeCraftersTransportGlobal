namespace TransportGlobal.Domain.Configurations
{
    public class TokenConfiguration
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int DurationInMinutes { get; set; }

        public string Key { get; set; }

        public TokenConfiguration(string issuer, string audience, int durationInMinutes, string key)
        {
            Issuer = issuer;
            Audience = audience;
            DurationInMinutes = durationInMinutes;
            Key = key;
        }
    }
}
