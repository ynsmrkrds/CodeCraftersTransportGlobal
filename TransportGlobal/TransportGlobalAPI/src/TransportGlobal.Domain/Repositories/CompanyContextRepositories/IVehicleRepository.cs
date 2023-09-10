using TransportGlobal.Domain.Entities.CompanyContextEntities;

namespace TransportGlobal.Domain.Repositories.CompanyContextRepositories
{
    public interface IVehicleRepository : IRepository<VehicleEntity>
    {
        bool IsExistsWithSameIdentificationNumber(string email);

        IEnumerable<VehicleEntity> GetAllByCompanyID(int companyID);
    }
}
