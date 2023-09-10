using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.TransportContextRepositories
{
    public class TransportRepository : Repository<TransportEntity>, ITransportRepository
    {
        public TransportRepository(TransportGlobalDBContext context) : base(context)
        {
        }
    }
}
