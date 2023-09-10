using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Repositories.UserContextRepositories;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories.UserContextRepositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(TransportGlobalDBContext context) : base(context)
        {
        }

        public bool IsExistsWithSameEmail(string email)
        {
            return _context.Users
                .Any(x => x.Email == email);
        }

        public UserEntity? ValidateUser(string email, string passwordHash)
        {
            return _context.Users.Where(x => x.Email == email && x.PasswordHash == passwordHash).FirstOrDefault();
        }

        public bool HasCompany(int id)
        {
            return _context.Users.First(x => x.ID == id).Company != null;
        }
    }
}
