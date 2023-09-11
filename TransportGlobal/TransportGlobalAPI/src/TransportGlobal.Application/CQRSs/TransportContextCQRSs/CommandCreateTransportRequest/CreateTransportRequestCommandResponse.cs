using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransportRequest
{
    public class CreateTransportRequestCommandResponse : BaseCommandResponseDTO
    {
        public CreateTransportRequestCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
