using MediatR;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetOwnChats
{
    public class GetOwnChatsQueryRequest : IRequest<GetOwnChatsQueryResponse>
    {
        public PaginationModel Pagination { get; set; }

        public GetOwnChatsQueryRequest(PaginationModel pagination)
        {
            Pagination = pagination;
        }
    }
}
