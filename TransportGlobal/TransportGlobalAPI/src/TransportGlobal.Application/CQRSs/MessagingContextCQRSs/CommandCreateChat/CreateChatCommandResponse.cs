using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandCreateChat
{
    public class CreateChatCommandResponse : BaseCommandResponseDTO
    {
        public CreateChatCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
