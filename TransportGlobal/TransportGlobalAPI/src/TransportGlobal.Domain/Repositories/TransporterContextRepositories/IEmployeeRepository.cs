using TransportGlobal.Domain.Entities.TransporterContextEntities;

namespace TransportGlobal.Domain.Repositories.TransporterContextRepositories
{
    public interface IEmployeeRepository : IRepository<EmployeeEntity>
    {
        bool IsExistsWithSameEmail(string email);

        IEnumerable<EmployeeEntity> GetAllByCompanyID(int companyID);

        IEnumerable<EmployeeEntity> GetAllByVehicleID(int vehicleID);
    }
}
