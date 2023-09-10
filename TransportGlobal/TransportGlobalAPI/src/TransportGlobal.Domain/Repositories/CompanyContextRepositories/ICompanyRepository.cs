using TransportGlobal.Domain.Entities.CompanyContextEntities;

namespace TransportGlobal.Domain.Repositories.CompanyContextRepositories
{
    public interface ICompanyRepository : IRepository<CompanyEntity>
    {
        bool IsExistsWithSameEmail(string email);
    }
}
