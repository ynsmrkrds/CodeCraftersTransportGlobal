using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandCreateReview
{
    public class CreateReviewCommandResponse : BaseCommandResponseDTO
    {
        public CreateReviewCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
