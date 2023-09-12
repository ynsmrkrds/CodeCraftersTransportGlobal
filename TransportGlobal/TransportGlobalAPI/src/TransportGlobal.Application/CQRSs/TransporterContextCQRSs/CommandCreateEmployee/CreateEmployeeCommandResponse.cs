using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateEmployee
{
    public class CreateEmployeeCommandResponse : BaseCommandResponseDTO
    {
        public CreateEmployeeCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
