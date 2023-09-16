using TransportGlobalWeb.UI.Models.ResponseModels.TransportResponseModels.TransportContract;

namespace TransportGlobalWeb.UI.Models.ResponseModels.ReviewResponseModels.Review
{
    public class CompanyReviewResponseModel : BaseResponseModel
    {
        public GetTransportContractResponseModel TransportContract { get; set; }

        public int Score { get; set; }

        public string Comment { get; set; }

        public CompanyReviewResponseModel(int id, DateTime createdDate, GetTransportContractResponseModel transportContract, int score, string comment) : base(id, createdDate)
        {
            TransportContract = transportContract;
            Score = score;
            Comment = comment;
        }
    }
}
