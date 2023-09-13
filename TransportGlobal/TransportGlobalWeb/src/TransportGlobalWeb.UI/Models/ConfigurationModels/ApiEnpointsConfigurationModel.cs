namespace TransportGlobalWeb.UI.Models.ConfigurationModels
{
    public class ApiEnpointsConfigurationModel
    {
        public string? BaseUrl { get; set; }

        public UserContextEndpointsConfigurationModel? UserContextEndpoints { get; set; }
    }
}
