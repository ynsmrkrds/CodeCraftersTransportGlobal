using TransportGlobal.Domain.Entities.TransporterContextEntities;

namespace TransportGlobal.Domain.Repositories.TransporterContextRepositories
{
    public interface IVehicleRepository : IRepository<VehicleEntity>
    {
        bool IsExistsWithSameIdentificationNumber(string email);

        IEnumerable<VehicleEntity> GetAllByCompanyID(int companyID);

        bool CanVehicleWork(int id);

        void OnVehicleEmployeesChanged(int id);

        bool? IsVehicleAtWork(int id);

        bool? IsOwner(int id, int userId);
    }
}
