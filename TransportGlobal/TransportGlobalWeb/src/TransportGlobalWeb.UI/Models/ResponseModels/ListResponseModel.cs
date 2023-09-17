using TransportGlobalWeb.UI.Models.ViewModels;

namespace TransportGlobalWeb.UI.Models.ResponseModels
{
    public class ListResponseModel<T> : BaseResponseModel where T : BaseViewModel
    {
        public ICollection<T> List { get; set; }

        public int TotalCount { get; set; }

        public ListResponseModel(ICollection<T> list, int totalCount)
        {
            List = list;
            TotalCount = totalCount;
        }
    }
}
