namespace TransportGlobal.Application.ViewModels
{
    public class BaseViewModel
    {
        public int ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public BaseViewModel(int id, DateTime createdDate, bool isDeleted)
        {
            ID = id;
            CreatedDate = createdDate;
            IsDeleted = isDeleted;
        }
    }
}
