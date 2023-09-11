using Microsoft.EntityFrameworkCore;
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
            return _context.Users
                .Where(x => x.Email == email && x.PasswordHash == passwordHash)
                .FirstOrDefault();
        }

        public bool HasCompany(int id)
        {
            return _context.Users
                .Include(x => x.Companies)
                .First(x => x.ID == id).Companies
                .Any(x => x.IsDeleted == false);
        }

        public override UserEntity? GetByID(int id)
        {
            return _context.Users
                .Include(x => x.Companies)
                .FirstOrDefault(x => x.ID == id);
        }
    }
}
