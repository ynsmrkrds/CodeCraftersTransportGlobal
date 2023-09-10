using TransportGlobal.Domain.Entities.CompanyContextEntities;

namespace TransportGlobal.Domain.Repositories.CompanyContextRepositories
{
    public interface IEmployeeRepository : IRepository<EmployeeEntity>
    {
        bool IsExistsWithSameEmail(string email);

        IEnumerable<EmployeeEntity> GetAllByCompanyID(int companyID);

        IEnumerable<EmployeeEntity> GetAllByVehicleID(int vehicleID);
    }
}
