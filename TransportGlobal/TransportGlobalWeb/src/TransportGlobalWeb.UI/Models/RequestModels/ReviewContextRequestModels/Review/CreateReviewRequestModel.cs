using System.ComponentModel.DataAnnotations;

namespace TransportGlobalWeb.UI.Models.RequestModels.ReviewContextRequestModels.Review
{
    public class CreateReviewRequestModel
    {
        public int TransportContractID { get; set; }

        public int Score { get; set; }

        public string Comment { get; set; } = string.Empty;
    }
}
