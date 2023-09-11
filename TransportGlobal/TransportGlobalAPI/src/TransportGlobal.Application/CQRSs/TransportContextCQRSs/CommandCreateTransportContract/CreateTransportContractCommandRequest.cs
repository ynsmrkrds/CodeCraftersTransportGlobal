using MediatR;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransportContract
{
    public class CreateTransportContractCommandRequest : IRequest<CreateTransportContractCommandResponse>
    {
        public int TransportRequestID { get; set; }

        public int VehicleID { get; set; }

        public double Price { get; set; }

        public CreateTransportContractCommandRequest(int transportRequestID, int vehicleID, double price)
        {
            TransportRequestID = transportRequestID;
            VehicleID = vehicleID;
            Price = price;
        }
    }
}
