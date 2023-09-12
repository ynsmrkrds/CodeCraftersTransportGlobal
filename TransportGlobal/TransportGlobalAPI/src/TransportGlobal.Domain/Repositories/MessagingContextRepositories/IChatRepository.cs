using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Enums.UserContextEnums;

namespace TransportGlobal.Domain.Repositories.MessagingContextRepositories
{
    public interface IChatRepository : IRepository<ChatEntity>
    {
        IEnumerable<ChatEntity> GetChatsByUserType(UserType userType, int userID);

        ChatEntity? GetByTransportRequestID(int transportRequestID, int senderUserID);

        bool IsExists(int senderUserID, int receiverUserID);

        bool? IsChatBelongToUser(int chatID, UserType userType, int userID);
    }
}
