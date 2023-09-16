using System.ComponentModel.DataAnnotations.Schema;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Enums.MessagingContextEnums;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.MessagingContextEntities
{
    public class MessageEntity : BaseEntity
    {
        [ForeignKey(nameof(Chat))]
        public int ChatID { get; set; }

        public ChatEntity? Chat { get; set; }

        [ForeignKey(nameof(SenderUser))]
        public int SenderUserID { get; set; }

        public UserEntity? SenderUser { get; set; }

        [ForeignKey(nameof(ReceiverUser))]
        public int ReceiverUserID { get; set; }

        public UserEntity? ReceiverUser { get; set; }

        public MessageContentType ContentType { get; set; }

        public string Content { get; set; }

        public DateTime SendingDate { get; set; }

        public MessageEntity(int chatID, int senderUserID, int receiverUserID, MessageContentType contentType, string content, DateTime sendingDate)
        {
            // Content Type is Contract, content must be contract id
            if (contentType == MessageContentType.Contract && int.TryParse(content, out int _) == false)
            {
                throw new ClientSideException(ExceptionConstants.MessageContentInvalid);
            }

            ChatID = chatID;
            SenderUserID = senderUserID;
            ReceiverUserID = receiverUserID;
            ContentType = contentType;
            Content = content;
            SendingDate = sendingDate;
        }
    }
}
