namespace TransportGlobalWeb.UI.Models.ResponseModels.TransportResponseModels.TransportRequest
{
    public class GetAllTransportRequestsResponseModel : BaseListResponseModel<GetTransportRequestResponseModel>
    {
        public GetAllTransportRequestsResponseModel(ICollection<GetTransportRequestResponseModel> list, int totalCount) : base(list, totalCount)
        {
        }
    }
}
