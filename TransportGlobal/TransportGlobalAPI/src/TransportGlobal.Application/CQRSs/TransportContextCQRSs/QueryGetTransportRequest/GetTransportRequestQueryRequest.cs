using MediatR;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetTransportRequest
{
    public class GetTransportRequestQueryRequest : IRequest<GetTransportRequestQueryResponse>
    {
        public int ID { get; set; }

        public GetTransportRequestQueryRequest(int id)
        {
            ID = id;
        }
    }
}
