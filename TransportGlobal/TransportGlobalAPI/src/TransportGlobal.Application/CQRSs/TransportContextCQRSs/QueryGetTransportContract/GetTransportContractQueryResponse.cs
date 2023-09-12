using TransportGlobal.Application.ViewModels.TransportContextViewModels;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetTransportContract
{
    public class GetTransportContractQueryResponse
    {
        public TransportContractViewModel TransportContract { get; set; }

        public GetTransportContractQueryResponse(TransportContractViewModel transportContract)
        {
            TransportContract = transportContract;
        }
    }
}
