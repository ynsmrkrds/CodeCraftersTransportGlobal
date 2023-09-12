using MediatR;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetPendingTransportRequests
{
    public class GetPendingTransportRequestsQueryRequest : IRequest<GetPendingTransportRequestsQueryResponse>
    {
        public PaginationModel Pagination { get; set; }

        public GetPendingTransportRequestsQueryRequest(PaginationModel pagination)
        {
            Pagination = pagination;
        }
    }
}
