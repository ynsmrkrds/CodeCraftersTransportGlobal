using TransportGlobal.Application.ViewModels.TransportContextViewModels;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetTransportRequest
{
    public class GetTransportRequestQueryResponse 
    {
        public TransportRequestViewModel TransportRequest { get; set; }

        public GetTransportRequestQueryResponse(TransportRequestViewModel transportRequest)
        {
            TransportRequest = transportRequest;
        }
    }
}
