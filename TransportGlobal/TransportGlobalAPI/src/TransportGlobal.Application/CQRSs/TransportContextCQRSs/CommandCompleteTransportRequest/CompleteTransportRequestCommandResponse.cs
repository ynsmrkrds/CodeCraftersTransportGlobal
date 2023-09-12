using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCompleteTransportRequest
{
    public class CompleteTransportRequestCommandResponse : BaseCommandResponseDTO
    {
        public CompleteTransportRequestCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
