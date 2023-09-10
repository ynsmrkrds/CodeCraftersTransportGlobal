using MediatR;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.QueryGetAllReviews
{
    public class GetAllReviewsQueryRequest : IRequest<GetAllReviewsQueryResponse>
    {
        public int TransportID { get; set; }

        public GetAllReviewsQueryRequest(int transportID)
        {
            TransportID = transportID;
        }
    }
}
