namespace TransportGlobalWeb.UI.Models.ResponseModels
{
    public abstract class BaseListResponseModel<T> : BaseResponseModel
    {
        public ICollection<T> List { get; set; }

        public int TotalCount { get; set; }

        protected BaseListResponseModel(ICollection<T> list, int totalCount) : base(0, DateTime.Now)
        {
            List = list;
            TotalCount = totalCount;
        }
    }
}
