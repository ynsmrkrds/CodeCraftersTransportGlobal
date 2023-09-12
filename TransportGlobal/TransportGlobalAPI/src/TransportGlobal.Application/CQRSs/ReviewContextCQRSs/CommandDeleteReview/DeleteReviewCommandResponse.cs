using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandDeleteReview
{
    public class DeleteReviewCommandResponse : BaseCommandResponseDTO
    {
        public DeleteReviewCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
