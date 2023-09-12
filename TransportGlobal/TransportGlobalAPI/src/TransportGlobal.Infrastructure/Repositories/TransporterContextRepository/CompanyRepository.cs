using Microsoft.EntityFrameworkCore;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.TransporterContextRepository
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

        public override IQueryable<CompanyEntity> GetAll()
        {
            return _context.Companies
                .Where(x => x.IsDeleted == false)
                .AsQueryable();
        }

        public CompanyEntity? GetCompanyByUserID(int userID)
        {
            return _context.Companies
                .FirstOrDefault(x => x.OwnerUserID == userID && x.IsDeleted == false);
        }
    }
}
