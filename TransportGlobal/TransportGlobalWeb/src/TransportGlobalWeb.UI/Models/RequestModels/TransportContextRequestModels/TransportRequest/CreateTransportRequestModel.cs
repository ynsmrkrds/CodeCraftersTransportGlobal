using TransportGlobalWeb.UI.Enums.TransportContextEnums;

namespace TransportGlobalWeb.UI.Models.RequestModels.TransportContextRequestModels.TransportRequest
{
    public class CreateTransportRequestModel
    {
        public TransportType TransportType { get; set; }

        public double Weight { get; set; }

        public double Volume { get; set; }

        public DateTime TransportDate { get; set; }

        public string LoadingAddress { get; set; } = string.Empty;

        public string DeliveryAddress { get; set; } = string.Empty;
    }
}
