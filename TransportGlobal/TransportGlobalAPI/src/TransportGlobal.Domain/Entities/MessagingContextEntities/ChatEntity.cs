using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.MessagingContextEntities
{
    public class ChatEntity : BaseEntity
    {
        public int TransportRequestID { get; set; }

        public int SenderUserID { get; set; }

        public int ReceiverUserID { get; set; }

        public ChatEntity(int transportRequestID, int senderUserID, int receiverUserID)
        {
            TransportRequestID = transportRequestID;
            SenderUserID = senderUserID;
            ReceiverUserID = receiverUserID;
        }
    }
}
