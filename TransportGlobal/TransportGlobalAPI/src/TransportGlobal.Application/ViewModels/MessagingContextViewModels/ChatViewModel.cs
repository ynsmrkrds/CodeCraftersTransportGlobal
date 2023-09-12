namespace TransportGlobal.Application.ViewModels.MessagingContextViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        public int TransportRequestID { get; set; }

        public int SenderUserID { get; set; }

        public int ReceiverUserID { get; set; }

        public ChatViewModel(int id, DateTime createdDate, bool isDeleted, int transportRequestID, int senderUserID, int receiverUserID) : base(id, createdDate, isDeleted)
        {
            TransportRequestID = transportRequestID;
            SenderUserID = senderUserID;
            ReceiverUserID = receiverUserID;
        }
    }
}
