namespace TransportGlobal.Application.ViewModels.MessagingContextViewModels
{
    public class MessageViewModel : BaseViewModel
    {
        public int ChatID { get; set; }

        public string Content { get; set; }

        public DateTime SendingDate { get; set; }

        public MessageViewModel(int id, DateTime createdDate, int chatID, string content, DateTime sendingDate) : base(id, createdDate)
        {
            ChatID = chatID;
            Content = content;
            SendingDate = sendingDate;
        }
    }
}
