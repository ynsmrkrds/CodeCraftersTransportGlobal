using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.MessagingContextEntities
{
    public class MessageEntity : BaseEntity
    {
        public int ChatID { get; set; }

        public string Content { get; set; }

        public DateTime SendingDate { get; set; }

        public bool WasRead { get; set; }

        public MessageEntity(int chatID, string content, DateTime sendingDate, bool wasRead)
        {
            ChatID = chatID;
            Content = content;
            SendingDate = sendingDate;
            WasRead = wasRead;
        }
    }
}
