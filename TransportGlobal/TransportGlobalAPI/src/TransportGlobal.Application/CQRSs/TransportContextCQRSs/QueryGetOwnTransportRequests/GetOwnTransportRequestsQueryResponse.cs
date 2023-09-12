using TransportGlobal.Application.ViewModels.TransportContextViewModels;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportRequests
{
    public class GetOwnTransportRequestsQueryResponse
    {
        public List<TransportRequestViewModel> TransportRequests { get; set; }

        public GetOwnTransportRequestsQueryResponse(List<TransportRequestViewModel> transportRequests)
        {
            TransportRequests = transportRequests;
        }
    }
}
