using MediatR;
using TransportGlobal.Domain.Enums.CompanyContextEntities;
using TransportGlobal.Domain.Enums.UserContextEnums;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandUpdateVehicle
{
    public class UpdateVehicleCommandRequest : IRequest<UpdateVehicleCommandResponse>
    {
        public int ID { get; set; }

        public string IdentificationNumber { get; set; }

        public VehicleType Type { get; set; }

        public VehicleStatusType Status { get; set; }

        public UpdateVehicleCommandRequest(int id, string identificationNumber, VehicleType type, VehicleStatusType status)
        {
            ID = id;
            IdentificationNumber = identificationNumber;
            Type = type;
            Status = status;
        }
    }
}
