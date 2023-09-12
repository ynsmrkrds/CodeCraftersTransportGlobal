using TransportGlobal.Application.ViewModels.MessagingContextViewModels;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetOwnChats
{
    public class GetOwnChatsQueryResponse
    {
        public List<ChatViewModel> Chats { get; set; }

        public GetOwnChatsQueryResponse(List<ChatViewModel> chats)
        {
            Chats = chats;
        }
    }
}
