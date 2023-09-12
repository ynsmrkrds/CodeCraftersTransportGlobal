using Microsoft.EntityFrameworkCore;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Enums.TransportContextEnums;
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
            return _context.TransportContracts
                .Include(x => x.User)
                .Include(x => x.Company)
                .Include(x => x.Vehicle)
                .Include(x => x.TransportRequest)
                .Where(x => x.IsAgreed)
                .AsQueryable();
        }

        public IEnumerable<TransportContractEntity> GetAllByUserID(int userID)
        {
            return GetAll()
                .Where(x => x.UserID == userID)
                .AsEnumerable();
        }

        public IEnumerable<TransportContractEntity> GetAllByCompanyID(int companyID)
        {
            return GetAll()
                .Where(x => x.CompanyID == companyID)
                .AsEnumerable();
        }

        public bool IsThereAgreedContract(int transportRequestID)
        {
            return _context.TransportContracts
                .Where(x => x.TransportRequestID == transportRequestID)
                .Any(x => x.IsAgreed);
        }

        public bool? IsOwner(int id, int userID)
        {
            return GetByID(id)?.UserID == userID;
        }

        public bool? CanReview(int id)
        {
            return _context.TransportContracts
                .Include(x => x.TransportRequest)
                .FirstOrDefault(x => x.ID == id)
                ?.TransportRequest
                ?.StatusType == StatusType.Done;
        }
    }
}
