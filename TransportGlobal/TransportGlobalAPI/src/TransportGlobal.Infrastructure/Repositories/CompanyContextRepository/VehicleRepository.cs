using TransportGlobal.Domain.Entities.CompanyContextEntities;
using TransportGlobal.Domain.Repositories.CompanyContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.CompanyContextRepository
{
    public class VehicleRepository : Repository<VehicleEntity>, IVehicleRepository
    {
        public VehicleRepository(TransportGlobalDBContext context) : base(context)
        {
        }

        public bool IsExistsWithSameIdentificationNumber(string identificationNumber)
        {
            return _context.Vehicles
                .Where(x => x.IdentificationNumber == identificationNumber)
                .Any();
        }

        public IEnumerable<VehicleEntity> GetAllByCompanyID(int companyID)
        {
            return _context.Vehicles
                .Where(x => x.CompanyID == companyID)
                .AsEnumerable();
        }
    }
}
