namespace TransportGlobal.Application.ViewModels.MessagingContextViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        public int TransportRequestID { get; set; }

        public int SenderUserID { get; set; }

        public int ReceiverUserID { get; set; }

        public ChatViewModel(int id, DateTime createDate, int transportRequestID, int senderUserID, int receiverUserID) : base(id, createDate)
        {
            TransportRequestID = transportRequestID;
            SenderUserID = senderUserID;
            ReceiverUserID = receiverUserID;
        }
    }
}
