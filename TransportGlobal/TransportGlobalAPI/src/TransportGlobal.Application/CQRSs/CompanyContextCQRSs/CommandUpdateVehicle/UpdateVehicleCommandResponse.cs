using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandUpdateVehicle
{
    public class UpdateVehicleCommandResponse : BaseCommandResponseDTO
    {
        public UpdateVehicleCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
