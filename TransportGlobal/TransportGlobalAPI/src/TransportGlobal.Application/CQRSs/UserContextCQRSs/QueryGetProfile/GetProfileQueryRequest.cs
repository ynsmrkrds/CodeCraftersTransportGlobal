using MediatR;

namespace TransportGlobal.Application.CQRSs.UserContextCQRSs.QueryGetProfile
{
    public class GetProfileQueryRequest : IRequest<GetProfileQueryResponse>
    {
    }
}
