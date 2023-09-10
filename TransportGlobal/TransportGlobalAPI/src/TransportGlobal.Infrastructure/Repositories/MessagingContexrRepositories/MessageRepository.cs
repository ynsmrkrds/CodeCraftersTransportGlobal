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
    }
}
