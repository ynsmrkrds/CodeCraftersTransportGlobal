using MediatR;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandCreateChat
{
    public class CreateChatCommandRequest : IRequest<CreateChatCommandResponse>
    {
        public int TransportRequestID { get; set; }

        public int SenderUserID { get; set; }

        public int ReceiverUserID { get; set; }

        public CreateChatCommandRequest(int transportRequestID, int senderUserID, int receiverUserID)
        {
            TransportRequestID = transportRequestID;
            SenderUserID = senderUserID;
            ReceiverUserID = receiverUserID;
        }
    }
}
