using TransportGlobal.Domain.Enums.MessagingContextEnums;

namespace TransportGlobal.Application.ViewModels.MessagingContextViewModels
{
    public class MessageViewModel : BaseViewModel
    {
        public int ChatID { get; set; }

        public MessageContentType ContentType { get; set; }

        public string Content { get; set; }

        public DateTime SendingDate { get; set; }

        public MessageViewModel(int id, DateTime createdDate, bool isDeleted, int chatID, MessageContentType contentType, string content, DateTime sendingDate) : base(id, createdDate, isDeleted)
        {
            ChatID = chatID;
            ContentType = contentType;
            Content = content;
            SendingDate = sendingDate;
        }
    }
}
