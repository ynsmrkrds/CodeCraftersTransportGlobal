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
            return GetAll()
                .Where(x => x.StatusType == TransportRequestStatusType.Pending)
                .AsEnumerable();
        }

        public IEnumerable<TransportRequestEntity> GetTransportRequestsByUserID(int userID)
        {
            return GetAll()
                .Where(x => x.UserID == userID)
                .AsEnumerable();
        }

        public bool? CanDelete(int id)
        {
            return GetAll()
                .Where(x => x.IsDeleted == false)
                .FirstOrDefault(x => x.ID == id)
                ?.StatusType == TransportRequestStatusType.Pending;
        }

        public bool? CanUpdate(int id)
        {
            return GetAll()
                .Where(x => x.IsDeleted == false)
                .FirstOrDefault(x => x.ID == id)
                ?.StatusType == TransportRequestStatusType.Pending;
        }
    }
}
