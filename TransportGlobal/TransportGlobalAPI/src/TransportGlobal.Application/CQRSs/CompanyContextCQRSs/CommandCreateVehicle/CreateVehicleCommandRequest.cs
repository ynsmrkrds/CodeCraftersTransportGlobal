using MediatR;
using TransportGlobal.Domain.Enums.CompanyContextEntities;
using TransportGlobal.Domain.Enums.UserContextEnums;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandCreateVehicle
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
