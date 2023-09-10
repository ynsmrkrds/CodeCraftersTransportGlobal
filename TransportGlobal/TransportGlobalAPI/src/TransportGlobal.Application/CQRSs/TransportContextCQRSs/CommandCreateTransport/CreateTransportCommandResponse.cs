using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransport
{
    public class CreateTransportCommandResponse : BaseCommandResponseDTO
    {
        public CreateTransportCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
