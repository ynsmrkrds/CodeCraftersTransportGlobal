using TransportGlobal.Application.ViewModels.TransportContextViewModels;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportContracts
{
    public class GetOwnTransportContractsQueryResponse
    {
        public List<TransportContractViewModel> TransportContracts { get; set; }

        public GetOwnTransportContractsQueryResponse(List<TransportContractViewModel> transportContracts)
        {
            TransportContracts = transportContracts;
        }
    }
}
