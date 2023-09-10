namespace TransportGlobal.Application.ViewModels.ReviewContextViewModels
{
    public class ReviewViewModel : BaseViewModel
    {
        public int Score { get; set; }

        public string Comment { get; set; }

        public ReviewViewModel(int id, DateTime createdDate, int score, string comment) : base(id, createdDate)
        {
            Score = score;
            Comment = comment;
        }
    }
}
