using MediatR;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransport
{
    public class CreateTransportCommandRequest :IRequest<CreateTransportCommandResponse>
    {
        public int TransportRequestID { get; set; }

        public int VehicleID { get; set; }

        public CreateTransportCommandRequest(int transportRequestID, int vehicleID)
        {
            TransportRequestID = transportRequestID;
            VehicleID = vehicleID;
        }
    }
}
