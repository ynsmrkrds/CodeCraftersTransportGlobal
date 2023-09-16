namespace TransportGlobalWeb.UI.Models.ResponseModels.ReviewResponseModels.Review
{
    public class GetCompanyReviewsResponseModel : BaseListResponseModel<CompanyReviewResponseModel>
    {
        public GetCompanyReviewsResponseModel(ICollection<CompanyReviewResponseModel> list, int totalCount) : base(list, totalCount)
        {
        }
    }
}
