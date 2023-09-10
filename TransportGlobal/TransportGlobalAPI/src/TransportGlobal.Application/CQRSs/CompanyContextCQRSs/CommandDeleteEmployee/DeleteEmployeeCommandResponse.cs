using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandDeleteEmployee
{
    public class DeleteEmployeeCommandResponse : BaseCommandResponseDTO
    {
        public DeleteEmployeeCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
