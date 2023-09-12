using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandUpdatePassword
{
    public class UpdatePasswordCommandResponse : BaseCommandResponseDTO
    {
        public UpdatePasswordCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
