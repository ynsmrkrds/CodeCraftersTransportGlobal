using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Enums.UserContextEnums;

namespace TransportGlobal.Domain.Repositories.TransportContextRepositories
{
    public interface ITransportContractRepository : IRepository<TransportContractEntity>
    {
        IEnumerable<TransportContractEntity> GetAllByUserID(int userID);

        IEnumerable<TransportContractEntity> GetAllByCompanyID(int companyID);

        bool IsThereAgreedContract(int transportRequestID);

        bool? IsOwner(int id, int userID);

        bool? CanReview(int id);

        int AgreeContact(int id);
    }
}
