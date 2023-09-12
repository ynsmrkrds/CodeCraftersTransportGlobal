namespace TransportGlobal.Application.ViewModels.ReviewContextViewModels
{
    public class ReviewViewModel : BaseViewModel
    {
        public int Score { get; set; }

        public string Comment { get; set; }

        public ReviewViewModel(int id, DateTime createdDate, bool isDeleted, int score, string comment) : base(id, createdDate, isDeleted)
        {
            Score = score;
            Comment = comment;
        }
    }
}
