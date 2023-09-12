using MediatR;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandDeleteReview
{
    public class DeleteReviewCommandRequest : IRequest<DeleteReviewCommandResponse>
    {
        public int ID { get; set; }

        public DeleteReviewCommandRequest(int id)
        {
            ID = id;
        }
    }
}
