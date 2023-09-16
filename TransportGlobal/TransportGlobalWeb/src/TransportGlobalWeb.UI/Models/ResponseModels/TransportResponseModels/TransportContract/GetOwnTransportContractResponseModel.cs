namespace TransportGlobalWeb.UI.Models.ResponseModels.TransportResponseModels.TransportContract
{
    public class GetOwnTransportContractResponseModel : BaseListResponseModel<GetTransportContractResponseModel>
    {
        public GetOwnTransportContractResponseModel(ICollection<GetTransportContractResponseModel> list, int totalCount) : base(list, totalCount)
        {
        }
    }
}
