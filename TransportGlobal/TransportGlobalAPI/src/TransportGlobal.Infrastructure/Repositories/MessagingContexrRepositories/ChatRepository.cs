using Microsoft.EntityFrameworkCore;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Enums.UserContextEnums;
using TransportGlobal.Domain.Repositories.MessagingContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.MessagingContexrRepositories
{
    public class ChatRepository : Repository<ChatEntity>, IChatRepository
    {
        public ChatRepository(TransportGlobalDBContext context) : base(context)
        {
        }

        public IEnumerable<ChatEntity> GetChatsByUserType(UserType userType, int userID)
        {
            IQueryable<ChatEntity> chats = GetAll()
                .Include(x => x.SenderUser)
                .Include(x => x.ReceiverUser)
                .OrderByDescending(x => x.CreatedDate);

            chats = userType switch
            {
                UserType.Shipper => chats.Where(x => x.SenderUserID == userID),
                UserType.Customer => chats.Where(x => x.ReceiverUserID == userID),
                _ => throw new NotImplementedException()
            };

            return chats.AsEnumerable();
        }

        public bool IsExists(int transportRequestID, int senderUserID, int receiverUserID)
        {
            return GetAll()
                .Where(x => x.IsDeleted == false)
                .Any(x => x.TransportRequestID == transportRequestID && x.SenderUserID == senderUserID && x.ReceiverUserID == receiverUserID);
        }

        public bool? IsChatBelongToUser(int chatID, UserType userType, int userID)
        {
            ChatEntity? chat = GetByID(chatID);
            if (chat == null) return null;

            return userType switch
            {
                UserType.Shipper => chat.SenderUserID == userID,
                UserType.Customer => chat.ReceiverUserID == userID,
                _ => throw new NotImplementedException()
            };
        }

        public ChatEntity? GetByTransportRequestID(int transportRequestID, int senderUserID)
        {
            return GetAll()
                .Where(x => x.IsDeleted == false)
                .FirstOrDefault(x => x.TransportRequestID == transportRequestID && x.SenderUserID == senderUserID);
        }
    }
}
