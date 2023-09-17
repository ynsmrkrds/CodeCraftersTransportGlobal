using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.DTOs.CQRSDTOs
{
    public abstract class BaseCommandResponseDTO
    {
        public ResponseConstantModel Response { get; private set; }

        public BaseCommandResponseDTO(ResponseConstantModel response)
        {
            Response = response;
        }
    }
}
