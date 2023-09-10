using TransportGlobal.Domain.Entities.CompanyContextEntities;
using TransportGlobal.Domain.Repositories.CompanyContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.CompanyContextRepository
{
    public class CompanyRepository : Repository<CompanyEntity>, ICompanyRepository
    {
        public CompanyRepository(TransportGlobalDBContext context) : base(context)
        {
        }

        public bool IsExistsWithSameEmail(string email)
        {
            return _context.Companies
                .Any(x => x.Email == email);
        }
    }
}
