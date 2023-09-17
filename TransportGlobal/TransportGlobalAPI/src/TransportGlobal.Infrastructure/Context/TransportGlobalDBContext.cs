using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Entities.ReviewContextEntities;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Infrastructure.Seeds.UserContextSeeds;

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

        #region Messaging Bounded Context DbSets
        public DbSet<ChatEntity> Chats { get; set; }

        public DbSet<MessageEntity> Messages { get; set; }
        #endregion

        #region Review Bounded Context DbSets 
        public DbSet<ReviewEntity> Reviews { get; set; }
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
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.TransportContracts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserEntity>()
               .HasMany(x => x.SenderUserChats)
               .WithOne(x => x.SenderUser)
               .HasForeignKey(x => x.SenderUserID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserEntity>()
               .HasMany(x => x.ReceiverUserChats)
               .WithOne(x => x.ReceiverUser)
               .HasForeignKey(x => x.ReceiverUserID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserEntity>()
             .HasMany(x => x.SentMessages)
             .WithOne(x => x.SenderUser)
             .HasForeignKey(x => x.SenderUserID)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.ReceivedMessages)
                .WithOne(x => x.ReceiverUser)
                .HasForeignKey(x => x.ReceiverUserID)
                .OnDelete(DeleteBehavior.NoAction);
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
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CompanyEntity>()
                .HasMany(x => x.Employees)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyID)
                .OnDelete(DeleteBehavior.NoAction);

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
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TransportRequestEntity>()
               .HasMany(x => x.Chats)
               .WithOne(x => x.TransportRequest)
               .HasForeignKey(x => x.TransportRequestID)
               .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Messaging Bounded Context Configurations
            modelBuilder.Entity<ChatEntity>()
              .HasMany(x => x.Messages)
              .WithOne(x => x.Chat)
              .HasForeignKey(x => x.ChatID)
              .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Review Bounded Context Configurations
            modelBuilder.Entity<ReviewEntity>()
              .HasOne(x => x.TransportContract)
              .WithOne(x => x.Review)
              .HasForeignKey<ReviewEntity>(x => x.TransportContractID)
              .OnDelete(DeleteBehavior.NoAction);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
