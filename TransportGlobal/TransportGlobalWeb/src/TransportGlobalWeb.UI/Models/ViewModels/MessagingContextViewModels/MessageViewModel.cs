using TransportGlobalWeb.UI.Enums.MessagingContextEnums;
using TransportGlobalWeb.UI.Models.ViewModels.UserContextViewModels;

namespace TransportGlobalWeb.UI.Models.ViewModels.MessagingContextViewModels
{
    public class MessageViewModel : BaseViewModel
    {
        public int ChatID { get; set; }

        public UserViewModel SenderUser { get; set; }

        public UserViewModel ReceiverUser { get; set; }

        public MessageContentType ContentType { get; set; }

        public string Content { get; set; }

        public DateTime SendingDate { get; set; }

        public MessageViewModel(int id, DateTime createdDate, bool isDeleted, int chatID, UserViewModel senderUser, UserViewModel receiverUser, MessageContentType contentType, string content, DateTime sendingDate) : base(id, createdDate, isDeleted)
        {
            ChatID = chatID;
            SenderUser = senderUser;
            ReceiverUser = receiverUser;
            ContentType = contentType;
            Content = content;
            SendingDate = sendingDate;
        }
    }
}
