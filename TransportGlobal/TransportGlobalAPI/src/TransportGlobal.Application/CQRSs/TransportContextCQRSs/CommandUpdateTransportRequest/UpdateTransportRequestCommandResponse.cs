using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandUpdateTransportRequest
{
    public class UpdateTransportRequestCommandResponse : BaseCommandResponseDTO
    {
        public UpdateTransportRequestCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
