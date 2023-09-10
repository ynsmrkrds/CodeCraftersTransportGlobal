using TransportGlobal.Application.ViewModels.TransportContextViewModels;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetPendingTransportRequest
{
    public class GetTransportRequestPendingQueryResponse
    {
        public List<TransportRequestViewModel> TransportRequests { get; set; }

        public GetTransportRequestPendingQueryResponse(List<TransportRequestViewModel> transportRequests)
        {
            TransportRequests = transportRequests;
        }
    }
}
