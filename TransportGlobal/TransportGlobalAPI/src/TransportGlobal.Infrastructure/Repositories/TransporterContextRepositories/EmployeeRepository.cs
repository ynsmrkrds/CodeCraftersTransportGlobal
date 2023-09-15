using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.TransporterContextRepositories
{
    public class EmployeeRepository : Repository<EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(TransportGlobalDBContext context) : base(context)
        {
        }

        public bool IsExistsWithSameEmail(string email)
        {
            return GetAll()
                .Where(x => x.IsDeleted == false)
                .Any(x => x.Email == email);
        }

        public IEnumerable<EmployeeEntity> GetAllByCompanyID(int companyID)
        {
            return GetAll()
                .Where(x => x.CompanyID == companyID)
                .Where(x => x.IsDeleted == false)
                .AsEnumerable();
        }

        public IEnumerable<EmployeeEntity> GetAllByVehicleID(int vehicleID)
        {
            return GetAll()
                .Where(x => x.VehicleID == vehicleID)
                .Where(x => x.IsDeleted == false)
                .AsEnumerable();
        }
    }
}
