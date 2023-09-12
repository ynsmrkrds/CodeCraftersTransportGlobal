using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandCreateUser
{
    public class CreateUserCommandResponse : BaseCommandResponseDTO
    {
        public CreateUserCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
