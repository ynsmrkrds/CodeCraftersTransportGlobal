using MediatR;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetChat
{
    public class GetChatQueryRequest : IRequest<GetChatQueryResponse>
    {
    }
}
