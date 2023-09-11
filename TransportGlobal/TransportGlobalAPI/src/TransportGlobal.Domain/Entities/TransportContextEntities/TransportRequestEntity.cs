using System.ComponentModel.DataAnnotations;
using TransportGlobal.Domain.Enums.TransportContextEnums;
using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.TransportContextEntities
{
    public class TransportRequestEntity : BaseEntity
    {
        public int UserID { get; set; }

        public TransportType TransportType { get; set; }

        public double Weight { get; set; }

        public double Volume { get; set; }

        public DateTime TransportDate { get; set; }

        [StringLength(150, MinimumLength = 10)]
        public string LoadingAddress { get; set; }

        [StringLength(150, MinimumLength = 10)]
        public string DeliveryAddress { get; set; }

        public StatusType StatusType { get; set; }

        public ICollection<TransportContractEntity> TransportContracts { get; set; } = new List<TransportContractEntity>();

        public TransportRequestEntity(int userID, TransportType transportType, double weight, double volume, DateTime transportDate, string loadingAddress, string deliveryAddress, StatusType statusType)
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
