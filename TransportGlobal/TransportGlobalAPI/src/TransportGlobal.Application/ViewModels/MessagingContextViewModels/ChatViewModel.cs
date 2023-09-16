using TransportGlobal.Application.ViewModels.TransportContextViewModels;
using TransportGlobal.Application.ViewModels.UserContextViewModels;

namespace TransportGlobal.Application.ViewModels.MessagingContextViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        public int TransportRequestID { get; set; }

        public UserViewModel SenderUser { get; set; }

        public UserViewModel ReceiverUser { get; set; }

        public ChatViewModel(int id, DateTime createdDate, bool isDeleted, int transportRequestID, UserViewModel senderUser, UserViewModel receiverUser) : base(id, createdDate, isDeleted)
        {
            TransportRequestID = transportRequestID;
            SenderUser = senderUser;
            ReceiverUser = receiverUser;
        }
    }
}
