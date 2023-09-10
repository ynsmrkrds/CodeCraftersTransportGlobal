using MediatR;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandDeleteChat
{
    public class DeleteChatCommandRequest : IRequest<DeleteChatCommandResponse>
    {
        public int ID { get; set; }

        public DeleteChatCommandRequest(int id)
        {
            ID = id;
        }
    }
}
