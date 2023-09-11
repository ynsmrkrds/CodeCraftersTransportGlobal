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

        #region Transport Bounded Context DbSets
        public DbSet<TransportRequestEntity> TransportRequests { get; set; }

        public DbSet<TransportEntity> Transports { get; set; }

        #endregion

        public TransportGlobalDBContext(DbContextOptions<TransportGlobalDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #region Transport Bounded Context Configurations
            modelBuilder.Entity<TransportEntity>()
                .HasOne(x => x.TransportRequest)
                .WithMany(x => x.Transports)
                .HasForeignKey(x => x.TransportRequestID)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
