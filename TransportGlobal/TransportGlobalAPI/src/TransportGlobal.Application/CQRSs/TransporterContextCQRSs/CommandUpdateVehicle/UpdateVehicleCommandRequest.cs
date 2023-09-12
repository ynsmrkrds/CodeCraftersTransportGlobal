using MediatR;
using TransportGlobal.Domain.Enums.TransporterContextEnums;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandUpdateVehicle
{
    public class UpdateVehicleCommandRequest : IRequest<UpdateVehicleCommandResponse>
    {
        public int ID { get; set; }

        public VehicleStatusType Status { get; set; }

        public UpdateVehicleCommandRequest(int id, VehicleStatusType status)
        {
            ID = id;
            Status = status;
        }
    }
}
