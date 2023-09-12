using MediatR;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportRequests
{
    public class GetOwnTransportRequestsQueryRequest : IRequest<GetOwnTransportRequestsQueryResponse>
    {
        public PaginationModel Pagination { get; set; }

        public GetOwnTransportRequestsQueryRequest(PaginationModel pagination)
        {
            Pagination = pagination;
        }
    }
}
