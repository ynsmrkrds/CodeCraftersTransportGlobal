using TransportGlobalWeb.UI.Models.ResponseModels.UserResponseModels.User;

namespace TransportGlobalWeb.UI.Models.ResponseModels.MessagingResponseModels.Chat
{
    public class ChatResponseModel : BaseResponseModel
    {
        public int TransportRequestID { get; set; }

        public GetProfileResponseModel SenderUser { get; set; }

        public GetProfileResponseModel ReceiverUser { get; set; }

        public ChatResponseModel(int id, DateTime createdDate, int transportRequestID, GetProfileResponseModel senderUser, GetProfileResponseModel receiverUser) : base(id, createdDate)
        {
            TransportRequestID = transportRequestID;
            SenderUser = senderUser;
            ReceiverUser = receiverUser;
        }
    }
}
