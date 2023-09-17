using TransportGlobal.Application.ViewModels.TransportContextViewModels;
using TransportGlobal.Application.ViewModels.UserContextViewModels;

namespace TransportGlobal.Application.ViewModels.MessagingContextViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        public TransportRequestViewModel TransportRequest { get; set; }

        public UserViewModel SenderUser { get; set; }

        public UserViewModel ReceiverUser { get; set; }

        public ChatViewModel(int id, DateTime createdDate, bool isDeleted, TransportRequestViewModel transportRequest, UserViewModel senderUser, UserViewModel receiverUser) : base(id, createdDate, isDeleted)
        {
            TransportRequest = transportRequest;
            SenderUser = senderUser;
            ReceiverUser = receiverUser;
        }
    }
}
