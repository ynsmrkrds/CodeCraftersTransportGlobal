using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandCreateMessage
{
    public class CreateMessageCommandResponse : BaseCommandResponseDTO
    {
        public CreateMessageCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
