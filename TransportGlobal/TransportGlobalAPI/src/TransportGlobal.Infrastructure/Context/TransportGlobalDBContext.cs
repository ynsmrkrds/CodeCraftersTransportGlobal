using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;

namespace TransportGlobal.Infrastructure.Context
{
    public class TransportGlobalDBContext : DbContext
    {
        #region User Bounded Context DbSets 
        public DbSet<UserEntity> Users { get; set; }
        #endregion

        #region Transporter Bounded Context DbSets 
        public DbSet<EmployeeEntity> Employees { get; set; }

        public DbSet<VehicleEntity> Vehicles { get; set; }

        public DbSet<CompanyEntity> Companies { get; set; }
        #endregion

        #region Transport Bounded Context DbSets
        public DbSet<TransportRequestEntity> TransportRequests { get; set; }

        public DbSet<TransportContractEntity> TransportContracts { get; set; }

        #endregion

        public TransportGlobalDBContext(DbContextOptions<TransportGlobalDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #region User Bounded Context Configurations
            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.Companies)
                .WithOne(x => x.OwnerUser)
                .HasForeignKey(x => x.OwnerUserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.TransportContracts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Transporter Bounded Context Configurations
            modelBuilder.Entity<VehicleEntity>()
                .HasMany(x => x.Employees)
                .WithOne(x => x.Vehicle)
                .HasForeignKey(x => x.VehicleID)
                .OnDelete(DeleteBehavior.NoAction);

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

            modelBuilder.Entity<CompanyEntity>()
               .HasMany(x => x.TransportContracts)
               .WithOne(x => x.Company)
               .HasForeignKey(x => x.CompanyID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VehicleEntity>()
               .HasMany(x => x.TransportContracts)
               .WithOne(x => x.Vehicle)
               .HasForeignKey(x => x.VehicleID)
               .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Transport Bounded Context Configurations
            modelBuilder.Entity<TransportContractEntity>()
                .HasOne(x => x.TransportRequest)
                .WithMany(x => x.TransportContracts)
                .HasForeignKey(x => x.TransportRequestID)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
