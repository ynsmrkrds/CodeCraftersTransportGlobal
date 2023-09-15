namespace TransportGlobalWeb.UI.Models.ResponseModels
{
    public abstract class BaseResponseModel
    {
        public int ID { get; set; }

        public DateTime CreatedDate { get; set; }

        protected BaseResponseModel(int id, DateTime createdDate)
        {
            ID = id;
            CreatedDate = createdDate;
        }
    }
}
