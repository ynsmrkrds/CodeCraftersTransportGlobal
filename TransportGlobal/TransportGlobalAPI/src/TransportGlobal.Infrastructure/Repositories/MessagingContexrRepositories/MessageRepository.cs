using Microsoft.EntityFrameworkCore;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Repositories.MessagingContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.MessagingContexrRepositories
{
    public class MessageRepository : Repository<MessageEntity>, IMessageRepository
    {
        public MessageRepository(TransportGlobalDBContext context) : base(context)
        {
        }

        public IEnumerable<MessageEntity> GetMessagesByChatID(int chatID)
        {
            return GetAll()
                .OrderByDescending(x => x.CreatedDate)
                .Where(x => x.ChatID == chatID)
                .AsEnumerable();
        }

        public bool? IsContractMessageBelongToUser(int userID, int chatID, int contractID)
        {
            return _context.Chats
                .Include(x => x.TransportRequest)
                .ThenInclude(x => x!.TransportContracts)
                .FirstOrDefault(x => x.ID == chatID)
                ?.TransportRequest
                ?.TransportContracts
                .Any(x => x.UserID == userID && x.ID == contractID);
        }
    }
}
