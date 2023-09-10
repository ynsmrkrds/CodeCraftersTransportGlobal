using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;

namespace TransportGlobal.Infrastructure.Context
{
    public class TransportGlobalDBContext : DbContext
    {
        #region User Bounded Context DbSets 
        public DbSet<UserEntity> Users { get; set; }
        #endregion

        #region
        public DbSet<TransportRequestEntity> TransportRequests { get; set; }
        #endregion

        #region
        public DbSet<TransportEntity> Transports { get; set; }
        #endregion

        public TransportGlobalDBContext(DbContextOptions<TransportGlobalDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
