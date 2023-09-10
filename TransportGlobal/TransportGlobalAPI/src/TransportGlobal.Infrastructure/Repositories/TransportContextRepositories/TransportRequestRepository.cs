using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Enums.TransportContextEnums;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.TransportContextRepositories
{
    public class TransportRequestRepository : Repository<TransportRequestEntity>, ITransportRequestRepository
    {
        public TransportRequestRepository(TransportGlobalDBContext context) : base(context)
        {
        }

        public List<TransportRequestEntity> GetTransportRequestWithPendingEntities()
        {
            return _context.TransportRequests.Where(x => x.StatusType == StatusType.Pending).ToList();
        }
    }
}
