using Microsoft.EntityFrameworkCore;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Enums.TransporterContextEnums;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.TransporterContextRepositories
{
    public class VehicleRepository : Repository<VehicleEntity>, IVehicleRepository
    {
        public VehicleRepository(TransportGlobalDBContext context) : base(context)
        {
        }

        public bool IsExistsWithSameIdentificationNumber(string identificationNumber)
        {
            return GetAll()
                .Where(x => x.IdentificationNumber == identificationNumber)
                .Where(x => x.IsDeleted == false)
                .Any();
        }

        public IEnumerable<VehicleEntity> GetAllByCompanyID(int companyID)
        {
            return GetAll()
                .Where(x => x.CompanyID == companyID)
                .AsEnumerable();
        }

        public bool CanVehicleWork(int id)
        {
            List<EmployeeEntity> employees = _context.Employees
                .Where(x => x.IsDeleted == false)
                .Where(x => x.VehicleID == id)
                .ToList();

            bool isThereDriver = employees.Any(x => x.Title == EmployeeTitle.Driver);
            bool isThereLoadingUnloadingOperator = employees.Any(x => x.Title == EmployeeTitle.LoadingUnloadingOperator);

            return isThereDriver && isThereLoadingUnloadingOperator;
        }

        public void OnVehicleEmployeesChanged(int id)
        {
            VehicleEntity? vehicle = GetAll().FirstOrDefault(x => x.ID == id);
            if (vehicle == null) return;

            if (vehicle.Status == VehicleStatusType.AtWork) return;

            vehicle.Status = CanVehicleWork(id) ? VehicleStatusType.Available : VehicleStatusType.NotWorking;

            _context.Update(vehicle);
            _context.SaveChanges();
        }

        public bool? IsVehicleAtWork(int id)
        {
            VehicleEntity? vehicle = GetAll()
                 .Where(x => x.IsDeleted == false)
                 .FirstOrDefault(x => x.ID == id);
            if (vehicle == null) return null;

            return vehicle.Status == VehicleStatusType.AtWork;
        }

        public bool? IsOwner(int id, int userId)
        {
            return GetAll()
                .Include(x => x.Company)
                .FirstOrDefault(x => x.ID == id)
                ?.Company
                ?.OwnerUserID == userId;
        }
    }
}
