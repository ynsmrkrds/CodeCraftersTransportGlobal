using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandCreateReview
{
    public class CreateReviewCommandRequest : IRequest<CreateReviewCommandResponse>
    {
        public int TransportContractID { get; set; }

        public int Score { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string Comment { get; set; }

        public CreateReviewCommandRequest(int transportContractID, int score, string comment)
        {
            TransportContractID = transportContractID;
            Score = score;
            Comment = comment;
        }
    }
}
