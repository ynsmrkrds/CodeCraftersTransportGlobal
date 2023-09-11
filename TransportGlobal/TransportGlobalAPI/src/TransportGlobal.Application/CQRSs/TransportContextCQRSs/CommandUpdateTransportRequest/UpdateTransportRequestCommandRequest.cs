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

        [StringLength(150, MinimumLength = 10)]
        public string LoadingAddress { get; set; }

        [StringLength(150, MinimumLength = 10)]
        public string DeliveryAddress { get; set; }

        public UpdateTransportRequestCommandRequest(int id, TransportType transportType, double weight, double volume, DateTime transportDate, string loadingAddress, string deliveryAddress)
        {
            ID = id;
            TransportType = transportType;
            Weight = weight;
            Volume = volume;
            TransportDate = transportDate;
            LoadingAddress = loadingAddress;
            DeliveryAddress = deliveryAddress;
        }
    }
}
