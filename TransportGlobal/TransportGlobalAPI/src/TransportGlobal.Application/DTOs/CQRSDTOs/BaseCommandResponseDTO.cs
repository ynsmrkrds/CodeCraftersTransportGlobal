using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.DTOs.CQRSDTOs
{
    public abstract class BaseCommandResponseDTO
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }

        protected BaseCommandResponseDTO(ResponseConstantModel response)
        {
            IsSuccessful = response.IsSuccessful;
            Message = response.Message;
        }
    }
}
