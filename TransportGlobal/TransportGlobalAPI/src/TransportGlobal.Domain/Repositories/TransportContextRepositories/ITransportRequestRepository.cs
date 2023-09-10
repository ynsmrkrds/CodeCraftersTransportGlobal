using TransportGlobal.Domain.Entities.TransportContextEntities;

namespace TransportGlobal.Domain.Repositories.TransportContextRepositories
{
    public interface ITransportRequestRepository : IRepository<TransportRequestEntity> 
    {
        List<TransportRequestEntity> GetTransportRequestWithPendingEntities();
    }
}
