using TransportGlobal.Application.ViewModels.TransportContextViewModels;

namespace TransportGlobal.Application.ViewModels.ReviewContextViewModels
{
    public class ReviewViewModel : BaseViewModel
    {
        public TransportContractViewModel TransportContract { get; set; }

        public int Score { get; set; }

        public string Comment { get; set; }

        public ReviewViewModel(int id, DateTime createdDate, bool isDeleted, TransportContractViewModel transportContract, int score, string comment) : base(id, createdDate, isDeleted)
        {
            TransportContract = transportContract;
            Score = score;
            Comment = comment;
        }
    }
}
