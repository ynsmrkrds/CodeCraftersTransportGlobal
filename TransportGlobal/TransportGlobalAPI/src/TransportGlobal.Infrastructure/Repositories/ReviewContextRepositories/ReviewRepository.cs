using TransportGlobal.Domain.Entities.ReviewContextEntities;
using TransportGlobal.Domain.Repositories.ReviewContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.ReviewContextRepositories
{
    public class ReviewRepository : Repository<ReviewEntity>, IReviewRepository
    {
        public ReviewRepository(TransportGlobalDBContext context) : base(context)
        {
        }
    }
}
