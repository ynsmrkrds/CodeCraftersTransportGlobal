using TransportGlobal.Domain.Entities.TransportContextEntities;

namespace TransportGlobal.Domain.Repositories.TransportContextRepositories
{
    public interface ITransportRequestRepository : IRepository<TransportRequestEntity> 
    {
        IEnumerable<TransportRequestEntity> GetPendingTransportRequests();

        IEnumerable<TransportRequestEntity> GetTransportRequestsByUserID(int userID);

        bool? CanDelete(int id);

        bool? CanUpdate(int id);
    }
}
