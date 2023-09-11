using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandDeleteTransportRequest
{
    public class DeleteTransportRequestCommandResponse : BaseCommandResponseDTO
    {
        public DeleteTransportRequestCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
