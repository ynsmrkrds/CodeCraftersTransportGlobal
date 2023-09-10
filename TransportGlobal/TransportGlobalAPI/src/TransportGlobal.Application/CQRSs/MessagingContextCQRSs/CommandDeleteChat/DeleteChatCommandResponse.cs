using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandDeleteChat
{
    public class DeleteChatCommandResponse : BaseCommandResponseDTO
    {
        public DeleteChatCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
