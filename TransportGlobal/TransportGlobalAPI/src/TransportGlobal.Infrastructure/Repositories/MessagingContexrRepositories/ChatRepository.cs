using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Repositories.MessagingContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.MessagingContexrRepositories
{
    public class ChatRepository : Repository<ChatEntity>, IChatRepository
    {
        public ChatRepository(TransportGlobalDBContext context) : base(context)
        {
        }
    }
}
