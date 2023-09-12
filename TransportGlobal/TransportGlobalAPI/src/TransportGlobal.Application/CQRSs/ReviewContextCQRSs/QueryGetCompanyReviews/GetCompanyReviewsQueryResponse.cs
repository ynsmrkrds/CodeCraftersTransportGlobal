using TransportGlobal.Application.ViewModels.ReviewContextViewModels;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.QueryGetCompanyReviews
{
    public class GetCompanyReviewsQueryResponse
    {
        public ICollection<ReviewViewModel> Reviews { get; set; }

        public GetCompanyReviewsQueryResponse(ICollection<ReviewViewModel> reviews)
        {
            Reviews = reviews;
        }
    }
}
