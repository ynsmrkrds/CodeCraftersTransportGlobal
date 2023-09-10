using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TransportGlobal.Domain.Entities.CompanyContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;

namespace TransportGlobal.Infrastructure.Context
{
    public class TransportGlobalDBContext : DbContext
    {
        #region User Bounded Context DbSets 
        public DbSet<UserEntity> Users { get; set; }
        #endregion

        #region Company Bounded Context DbSets 
        public DbSet<EmployeeEntity> Employees { get; set; }

        public DbSet<VehicleEntity> Vehicles { get; set; }

        public DbSet<CompanyEntity> Companies { get; set; }
        #endregion

        public TransportGlobalDBContext(DbContextOptions<TransportGlobalDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #region User Bounded Context Configurations
            modelBuilder.Entity<UserEntity>()
                .HasOne(x => x.Company)
                .WithOne(x => x.OwnerUser)
                .HasForeignKey<CompanyEntity>(x => x.OwnerUserID);
            #endregion

            #region Company Bounded Context Configurations
            modelBuilder.Entity<VehicleEntity>()
                .HasMany(x => x.Employees)
                .WithOne(x => x.Vehicle)
                .HasForeignKey(x => x.VehicleID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyEntity>()
                .HasMany(x => x.Vehicles)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyEntity>()
                .HasMany(x => x.Employees)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
