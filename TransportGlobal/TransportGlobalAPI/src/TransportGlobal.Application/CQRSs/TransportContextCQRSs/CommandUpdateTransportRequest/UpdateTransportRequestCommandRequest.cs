using MediatR;
using System.ComponentModel.DataAnnotations;
using TransportGlobal.Domain.Enums.TransportContextEnums;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandUpdateTransportRequest
{
    public class UpdateTransportRequestCommandRequest : IRequest<UpdateTransportRequestCommandResponse>
    {
        public int ID { get; set; }

        public TransportType TransportType { get; set; }

        public double Weight { get; set; }

        public double Volume { get; set; }

        public DateTime TransportDate { get; set; }

        public DateTime RequestDate { get; set; }

        [StringLength(150, MinimumLength = 10)]
        public string LoadingAddress { get; set; }

        [StringLength(150, MinimumLength = 10)]
        public string DeliveryAddress { get; set; }

        public StatusType StatusType { get; set; }

        public UpdateTransportRequestCommandRequest(int id, TransportType transportType, double weight, double volume, DateTime transportDate, DateTime requestDate, string loadingAddress, string deliveryAddress, StatusType statusType)
        {
            ID = id;
            TransportType = transportType;
            Weight = weight;
            Volume = volume;
            TransportDate = transportDate;
            RequestDate = requestDate;
            LoadingAddress = loadingAddress;
            DeliveryAddress = deliveryAddress;
            StatusType = statusType;
        }
    }
}
