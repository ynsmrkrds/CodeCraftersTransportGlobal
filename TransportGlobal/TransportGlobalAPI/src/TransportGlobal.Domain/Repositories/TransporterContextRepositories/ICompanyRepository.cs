using TransportGlobal.Domain.Entities.TransporterContextEntities;

namespace TransportGlobal.Domain.Repositories.TransporterContextRepositories
{
    public interface ICompanyRepository : IRepository<CompanyEntity>
    {
        bool IsExistsWithSameEmail(string email);

        CompanyEntity? GetCompanyByUserID(int userID);

        bool IsCompanyActive(int id);
    }
}
