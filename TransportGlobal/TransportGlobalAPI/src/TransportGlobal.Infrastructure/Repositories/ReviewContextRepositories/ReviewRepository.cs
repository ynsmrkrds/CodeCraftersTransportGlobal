using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<ReviewEntity> GetReviewsByCompanyID(int companyID)
        {
            return GetAll()
                .Include(x => x.TransportContract)
                .ThenInclude(x => x!.User)
                .Where(x => x.TransportContract != null & x.TransportContract!.CompanyID == companyID)
                .AsEnumerable();
        }
    }
}
