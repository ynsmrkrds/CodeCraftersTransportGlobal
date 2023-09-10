using MediatR;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandCreateMessage
{
    public class CreateMessageCommandRequest :IRequest<CreateMessageCommandResponse>
    {
        public int ChatID { get; set; }

        public string Content { get; set; }

        public DateTime SendingDate { get; set; }

        public bool WasRead { get; set; }

        public CreateMessageCommandRequest(int chatID, string content, DateTime sendingDate, bool wasRead)
        {
            ChatID = chatID;
            Content = content;
            SendingDate = sendingDate;
            WasRead = wasRead;
        }
    }
}
