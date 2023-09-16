using TransportGlobalWeb.UI.Enums.MessagingContextEnums;
using TransportGlobalWeb.UI.Models.ResponseModels.UserResponseModels.User;

namespace TransportGlobalWeb.UI.Models.ResponseModels.MessagingResponseModels.Message
{
    public class MessageResponseModel : BaseResponseModel
    {
        public int ChatID { get; set; }

        public GetProfileResponseModel SenderUser { get; set; }

        public GetProfileResponseModel ReceiverUser { get; set; }

        public MessageContentType ContentType { get; set; }

        public string Content { get; set; }

        public DateTime SendingDate { get; set; }

        public MessageResponseModel(int id, DateTime createdDate, int chatID, GetProfileResponseModel senderUser, GetProfileResponseModel receiverUser, MessageContentType contentType, string content, DateTime sendingDate) : base(id, createdDate)
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
