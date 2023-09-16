namespace TransportGlobalWeb.UI.Models.ConfigurationModels.TransportContextConfiguraitonModels
{
    public class TransportRequestEndpointsConfigurationModel
    {
        public string? CrudTransportRequest { get; set; }

        public string? GetOwnTransportRequest { get; set; }

        public string? GetPendingTransportRequests { get; set; }

        public string? CompleteTransportRequest { get; set; }
    }
}
