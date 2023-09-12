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
            return _context.TransportContracts
                .Include(x => x.Review)
                .Where(x => x.CompanyID == companyID && x.Review != null)
                .Select(x => x.Review!)
                .AsEnumerable();
        }
    }
}
