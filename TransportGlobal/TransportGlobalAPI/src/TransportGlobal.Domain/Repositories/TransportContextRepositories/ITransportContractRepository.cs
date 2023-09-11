using TransportGlobal.Domain.Entities.TransportContextEntities;

namespace TransportGlobal.Domain.Repositories.TransportContextRepositories
{
    public interface ITransportContractRepository : IRepository<TransportContractEntity>
    {
        IEnumerable<TransportContractEntity> GetAllByUserID(int userID);

        IEnumerable<TransportContractEntity> GetAllByCompanyID(int companyID);

        bool IsThereAgreedContract(int transportRequestID);
    }
}
