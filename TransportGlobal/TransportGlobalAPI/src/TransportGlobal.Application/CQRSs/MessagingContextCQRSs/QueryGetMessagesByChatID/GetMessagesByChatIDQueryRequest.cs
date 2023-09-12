using MediatR;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetMessagesByChatID
{
    public class GetMessagesByChatIDQueryRequest : IRequest<GetMessagesByChatIDQueryResponse>
    {
        public int ChatID { get; set; }

        public PaginationModel Pagination { get; set; }

        public GetMessagesByChatIDQueryRequest(int chatID, PaginationModel pagination)
        {
            ChatID = chatID;
            Pagination = pagination;
        }
    }
}
