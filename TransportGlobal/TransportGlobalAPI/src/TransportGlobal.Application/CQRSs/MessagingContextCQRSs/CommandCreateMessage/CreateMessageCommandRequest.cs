using MediatR;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandCreateMessage
{
    public class CreateMessageCommandRequest : IRequest<CreateMessageCommandResponse>
    {
        public int ChatID { get; set; }

        public string Content { get; set; }

        public CreateMessageCommandRequest(int chatID, string content)
        {
            ChatID = chatID;
            Content = content;
        }
    }
}
