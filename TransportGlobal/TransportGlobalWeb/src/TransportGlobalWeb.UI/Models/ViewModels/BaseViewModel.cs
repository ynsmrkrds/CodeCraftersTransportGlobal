namespace TransportGlobalWeb.UI.Models.ViewModels
{
    public abstract class BaseViewModel : IApiData
    {
        public int ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        protected BaseViewModel(int id, DateTime createdDate, bool ısDeleted)
        {
            ID = id;
            CreatedDate = createdDate;
            IsDeleted = ısDeleted;
        }
    }
}
