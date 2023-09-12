using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandUpdateUser
{
    public class UpdateUserCommandResponse : BaseCommandResponseDTO
    {
        public UpdateUserCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
