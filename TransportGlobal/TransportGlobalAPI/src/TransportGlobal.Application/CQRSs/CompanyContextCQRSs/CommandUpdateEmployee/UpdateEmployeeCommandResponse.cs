using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandUpdateEmployee
{
    public class UpdateEmployeeCommandResponse : BaseCommandResponseDTO
    {
        public UpdateEmployeeCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
