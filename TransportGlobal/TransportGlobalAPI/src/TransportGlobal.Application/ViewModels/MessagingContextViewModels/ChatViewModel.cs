namespace TransportGlobal.Application.ViewModels.MessagingContextViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        public int TransportRequestID { get; set; }

        public int SenderUserID { get; set; }

        public int ReceiverUserID { get; set; }

        public ChatViewModel(int id, DateTime createdDate, int transportRequestID, int senderUserID, int receiverUserID) : base(id, createdDate)
        {
            TransportRequestID = transportRequestID;
            SenderUserID = senderUserID;
            ReceiverUserID = receiverUserID;
        }
    }
}
