namespace TransportGlobal.Application.ViewModels
{
    public class BaseViewModel
    {
        public int ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public BaseViewModel(int id, DateTime createdDate)
        {
            ID = id;
            CreatedDate = createdDate;
        }
    }
}
