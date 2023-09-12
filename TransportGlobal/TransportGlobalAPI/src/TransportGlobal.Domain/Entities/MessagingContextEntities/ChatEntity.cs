using System.ComponentModel.DataAnnotations.Schema;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.MessagingContextEntities
{
    public class ChatEntity : BaseEntity
    {
        [ForeignKey(nameof(TransportRequest))]
        public int TransportRequestID { get; set; }

        public TransportRequestEntity? TransportRequest { get; set; }

        [ForeignKey(nameof(SenderUser))]
        public int SenderUserID { get; set; }

        public UserEntity? SenderUser { get; set; }

        [ForeignKey(nameof(ReceiverUser))]
        public int ReceiverUserID { get; set; }

        public UserEntity? ReceiverUser { get; set; }

        public ICollection<MessageEntity> Messages { get; set; } = new List<MessageEntity>();

        public ChatEntity(int transportRequestID, int senderUserID, int receiverUserID)
        {
            TransportRequestID = transportRequestID;
            SenderUserID = senderUserID;
            ReceiverUserID = receiverUserID;
        }
    }
}
