using Microsoft.EntityFrameworkCore;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Enums.TransportContextEnums;
using TransportGlobal.Domain.Enums.TransporterContextEnums;
using TransportGlobal.Domain.Enums.UserContextEnums;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.TransportContextRepositories
{
    public class TransportContractRepository : Repository<TransportContractEntity>, ITransportContractRepository
    {
        public TransportContractRepository(TransportGlobalDBContext context) : base(context)
        {
        }

        public override TransportContractEntity? GetByID(int id)
        {
            return GetAll()
                .FirstOrDefault(x => x.ID == id);
        }

        public override IQueryable<TransportContractEntity> GetAll()
        {
            return base.GetAll()
                .Include(x => x.User)
                .Include(x => x.Company)
                .Include(x => x.Vehicle)
                .Include(x => x.TransportRequest)
                .AsQueryable();
        }

        public IEnumerable<TransportContractEntity> GetAllByUserID(int userID)
        {
            return GetAll()
                .Where(x => x.UserID == userID)
                .Where(x => x.Status == TransportContractStatusType.Agreed)
                .AsEnumerable();
        }

        public IEnumerable<TransportContractEntity> GetAllByCompanyID(int companyID)
        {
            return GetAll()
                .Where(x => x.CompanyID == companyID)
                .Where(x => x.Status == TransportContractStatusType.Agreed)
                .AsEnumerable();
        }

        public bool IsThereAgreedContract(int transportRequestID)
        {
            return GetAll()
                .Where(x => x.TransportRequestID == transportRequestID)
                .Where(x => x.IsDeleted == false)
                .Any(x => x.Status == TransportContractStatusType.Agreed);
        }

        public bool? IsOwner(int id, int userID)
        {
            return GetByID(id)?.UserID == userID;
        }

        public bool? CanReview(int id)
        {
            return GetAll()
                .Include(x => x.TransportRequest)
                .Where(x => x.IsDeleted == false)
                .FirstOrDefault(x => x.ID == id)
                ?.TransportRequest
                ?.StatusType == TransportRequestStatusType.Done;
        }

        public int AgreeContact(int id)
        {
            TransportContractEntity? transportContractEntity = GetByID(id);
            if (transportContractEntity == null) return 0;

            transportContractEntity.Status = TransportContractStatusType.Agreed;
            transportContractEntity.TransportRequest!.StatusType = TransportRequestStatusType.InProcess;
            transportContractEntity.Vehicle!.Status = VehicleStatusType.AtWork;

            transportContractEntity = Update(transportContractEntity);

            List<TransportContractEntity> offeredContracts = _context.TransportContracts
                .Where(x => x.ID != transportContractEntity.ID)
                .Where(x => x.CompanyID == transportContractEntity.CompanyID && x.TransportRequestID == transportContractEntity.TransportRequestID)
                .ToList();

            foreach (TransportContractEntity offeredContract in offeredContracts)
            {
                offeredContract.Status = TransportContractStatusType.NotAgreed;
                Update(offeredContract);
            }

            return SaveChanges();
        }
    }
}
