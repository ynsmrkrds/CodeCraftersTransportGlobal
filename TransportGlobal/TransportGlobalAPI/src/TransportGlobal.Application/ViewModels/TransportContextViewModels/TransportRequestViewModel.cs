using TransportGlobal.Domain.Enums.TransportContextEnums;

namespace TransportGlobal.Application.ViewModels.TransportContextViewModels
{
    public class TransportRequestViewModel : BaseViewModel
    {
        public int UserID { get; set; }

        public TransportType TransportType { get; set; }

        public double Weight { get; set; }

        public double Volume { get; set; }

        public DateTime TransportDate { get; set; }

        public string LoadingAddress { get; set; }

        public string DeliveryAddress { get; set; }

        public TransportRequestStatusType StatusType { get; set; }

        public TransportRequestViewModel(int id, DateTime createdDate, bool isDeleted, int userID, TransportType transportType, double weight, double volume, DateTime transportDate, string loadingAddress, string deliveryAddress, TransportRequestStatusType statusType) : base(id, createdDate, isDeleted)
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
