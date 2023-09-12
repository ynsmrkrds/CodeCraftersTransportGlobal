using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandUpdateEmployee
{
    public class UpdateEmployeeCommandResponse : BaseCommandResponseDTO
    {
        public UpdateEmployeeCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
