using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;

namespace TransportGlobal.Domain.Repositories.UserContextRepositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        bool IsExistsWithSameEmail(string email);

        UserEntity? ValidateUser(string email, string passwordHash);

        bool HasCompany(int id);
    }
}
