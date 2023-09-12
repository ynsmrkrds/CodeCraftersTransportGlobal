using TransportGlobal.Domain.Entities.ReviewContextEntities;

namespace TransportGlobal.Domain.Repositories.ReviewContextRepositories
{
    public interface IReviewRepository : IRepository<ReviewEntity>
    {
        IEnumerable<ReviewEntity> GetReviewsByCompanyID(int companyID);
    }
}
