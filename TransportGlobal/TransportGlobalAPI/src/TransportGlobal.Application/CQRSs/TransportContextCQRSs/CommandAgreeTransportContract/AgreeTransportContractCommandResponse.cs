using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandAgreeTransportContract
{
    public class AgreeTransportContractCommandResponse : BaseCommandResponseDTO
    {
        public AgreeTransportContractCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
