using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandDeleteVehicle
{
    public class DeleteVehicleCommandResponse : BaseCommandResponseDTO
    {
        public DeleteVehicleCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
