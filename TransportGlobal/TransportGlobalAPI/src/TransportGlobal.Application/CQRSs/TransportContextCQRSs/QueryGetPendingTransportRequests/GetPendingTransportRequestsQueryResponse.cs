using TransportGlobal.Application.ViewModels.TransportContextViewModels;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetPendingTransportRequests
{
    public class GetPendingTransportRequestsQueryResponse
    {
        public List<TransportRequestViewModel> TransportRequests { get; set; }

        public GetPendingTransportRequestsQueryResponse(List<TransportRequestViewModel> transportRequests)
        {
            TransportRequests = transportRequests;
        }
    }
}
