using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandDeleteVehicle
{
    public class DeleteVehicleCommandResponse : BaseCommandResponseDTO
    {
        public DeleteVehicleCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
