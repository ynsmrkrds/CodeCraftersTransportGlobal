using MediatR;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetMessage
{
    public class GetMessageQueryRequest : IRequest<GetMessageQueryResponse>
    {
    }
}
