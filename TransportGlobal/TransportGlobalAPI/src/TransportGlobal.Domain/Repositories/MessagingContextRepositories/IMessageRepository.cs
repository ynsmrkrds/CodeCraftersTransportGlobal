using TransportGlobal.Domain.Entities.MessagingContextEntities;

namespace TransportGlobal.Domain.Repositories.MessagingContextRepositories
{
    public interface IMessageRepository : IRepository<MessageEntity>
    {
        IEnumerable<MessageEntity> GetMessagesByChatID(int chatID);

        bool? IsContractMessageBelongToUser(int userID, int chatID, int contractID);
    }
}
