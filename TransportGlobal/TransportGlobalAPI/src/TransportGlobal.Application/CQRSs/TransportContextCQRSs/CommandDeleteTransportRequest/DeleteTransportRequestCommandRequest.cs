using MediatR;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandDeleteTransportRequest
{
    public class DeleteTransportRequestCommandRequest : IRequest<DeleteTransportRequestCommandResponse>
    {
        public int ID { get; set; }

        public DeleteTransportRequestCommandRequest(int id)
        {
            ID = id;
        }
    }
}
