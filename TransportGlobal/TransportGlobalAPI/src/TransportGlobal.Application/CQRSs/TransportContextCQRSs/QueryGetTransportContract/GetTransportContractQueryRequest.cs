using MediatR;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetTransportContract
{
    public class GetTransportContractQueryRequest : IRequest<GetTransportContractQueryResponse>
    {
        public int ID { get; set; }

        public GetTransportContractQueryRequest(int id)
        {
            ID = id;
        }
    }
}
