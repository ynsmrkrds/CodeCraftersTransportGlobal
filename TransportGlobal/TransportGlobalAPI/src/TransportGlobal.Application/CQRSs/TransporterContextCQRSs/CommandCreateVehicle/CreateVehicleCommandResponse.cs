using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateVehicle
{
    public class CreateVehicleCommandResponse : BaseCommandResponseDTO
    {
        public CreateVehicleCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
