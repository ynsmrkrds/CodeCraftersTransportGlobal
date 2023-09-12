using MediatR;
using TransportGlobal.Domain.Enums.TransporterContextEnums;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateVehicle
{
    public class CreateVehicleCommandRequest : IRequest<CreateVehicleCommandResponse>
    {
        public string IdentificationNumber { get; set; }

        public VehicleType Type { get; set; }

        public CreateVehicleCommandRequest(string identificationNumber, VehicleType type)
        {
            IdentificationNumber = identificationNumber;
            Type = type;
        }
    }
}
