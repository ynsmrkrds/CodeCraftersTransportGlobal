using TransportGlobal.Application.ViewModels.ReviewContextViewModels;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.QueryGetAllReviews
{
    public class GetAllReviewsQueryResponse
    {
        public ICollection<ReviewViewModel> Reviews { get; set; }

        public GetAllReviewsQueryResponse(ICollection<ReviewViewModel> reviews)
        {
            Reviews = reviews;
        }
    }
}
