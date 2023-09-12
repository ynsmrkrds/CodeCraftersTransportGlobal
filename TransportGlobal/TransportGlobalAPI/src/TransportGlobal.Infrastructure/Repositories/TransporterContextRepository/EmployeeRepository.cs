using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.TransporterContextRepository
{
    public class EmployeeRepository : Repository<EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(TransportGlobalDBContext context) : base(context)
        {
        }

        public bool IsExistsWithSameEmail(string email)
        {
            return _context.Employees
                .Any(x => x.Email == email);
        }

        public IEnumerable<EmployeeEntity> GetAllByCompanyID(int companyID)
        {
            return _context.Employees
                .Where(x => x.CompanyID == companyID)
                .AsEnumerable();
        }

        public IEnumerable<EmployeeEntity> GetAllByVehicleID(int vehicleID)
        {
            return _context.Employees
                .Where(x => x.VehicleID == vehicleID)
                .AsEnumerable();
        }
    }
}
