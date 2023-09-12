using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.TransporterContextRepositories
{
    public class CompanyRepository : Repository<CompanyEntity>, ICompanyRepository
    {
        public CompanyRepository(TransportGlobalDBContext context) : base(context)
        {
        }

        public bool IsExistsWithSameEmail(string email)
        {
            return GetAll()
                .Where(x => x.IsDeleted == false)
                .Any(x => x.Email == email);
        }

        public CompanyEntity? GetCompanyByUserID(int userID)
        {
            return GetAll()
                .FirstOrDefault(x => x.OwnerUserID == userID);
        }
    }
}
