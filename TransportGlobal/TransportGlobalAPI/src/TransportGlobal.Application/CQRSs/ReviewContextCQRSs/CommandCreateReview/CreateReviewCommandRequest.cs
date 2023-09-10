using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandCreateReview
{
    public class CreateReviewCommandRequest : IRequest<CreateReviewCommandResponse>
    {
        public int TransportID { get; set; }

        public int Score { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string Comment { get; set; }

        public CreateReviewCommandRequest(int transportID, int score, string comment)
        {
            TransportID = transportID;
            Score = score;
            Comment = comment;
        }
    }
}
