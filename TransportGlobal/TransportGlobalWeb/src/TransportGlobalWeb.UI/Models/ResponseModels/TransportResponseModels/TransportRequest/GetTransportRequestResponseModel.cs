using TransportGlobalWeb.UI.Enums.TransportContextEnums;

namespace TransportGlobalWeb.UI.Models.ResponseModels.TransportResponseModels.TransportRequest
{
    public class GetTransportRequestResponseModel : BaseResponseModel
    {
        public int UserID { get; set; }

        public TransportType TransportType { get; set; }

        public double Weight { get; set; }

        public double Volume { get; set; }

        public DateTime TransportDate { get; set; }

        public string LoadingAddress { get; set; }

        public string DeliveryAddress { get; set; }

        public TransportRequestStatusType StatusType { get; set; }

        public GetTransportRequestResponseModel(int id, DateTime createdDate, int userID, TransportType transportType, double weight, double volume, DateTime transportDate, string loadingAddress, string deliveryAddress, TransportRequestStatusType statusType) : base(id, createdDate)
        {
            UserID = userID;
            TransportType = transportType;
            Weight = weight;
            Volume = volume;
            TransportDate = transportDate;
            LoadingAddress = loadingAddress;
            DeliveryAddress = deliveryAddress;
            StatusType = statusType;
        }
    }
}
