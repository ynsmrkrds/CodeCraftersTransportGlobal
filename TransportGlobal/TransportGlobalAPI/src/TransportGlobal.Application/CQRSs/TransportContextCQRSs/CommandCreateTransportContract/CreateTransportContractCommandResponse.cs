using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransportContract
{
    public class CreateTransportContractCommandResponse : BaseCommandResponseDTO
    {
        public CreateTransportContractCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
