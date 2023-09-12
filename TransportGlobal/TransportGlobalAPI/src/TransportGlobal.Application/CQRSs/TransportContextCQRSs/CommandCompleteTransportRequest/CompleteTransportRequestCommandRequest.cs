using MediatR;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCompleteTransportRequest
{
    public class CompleteTransportRequestCommandRequest : IRequest<CompleteTransportRequestCommandResponse>
    {
        public int ID { get; set; }

        public CompleteTransportRequestCommandRequest(int id)
        {
            ID = id;
        }
    }
}
