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

        public IEnumerable<TransportRequestEntity> GetPendingTransportRequests()
        {
            return _context.TransportRequests
                .Where(x => x.StatusType == StatusType.Pending)
                .AsEnumerable();
        }

        public IEnumerable<TransportRequestEntity> GetTransportRequestsByUserID(int userID)
        {
            return _context.TransportRequests.Where(x => x.UserID == userID).AsEnumerable();
        }

        public bool? CanDelete(int id)
        {
            TransportRequestEntity? transportRequest = _context.TransportRequests.FirstOrDefault(x => x.ID == id);
            if (transportRequest == null) return null;

            return transportRequest.StatusType == StatusType.Pending || transportRequest.StatusType == StatusType.Cancelled;
        }

        public bool? CanUpdate(int id)
        {
            TransportRequestEntity? transportRequest = _context.TransportRequests.FirstOrDefault(x => x.ID == id);
            if (transportRequest == null) return null;

            return transportRequest.StatusType == StatusType.Pending;
        }
    }
}
