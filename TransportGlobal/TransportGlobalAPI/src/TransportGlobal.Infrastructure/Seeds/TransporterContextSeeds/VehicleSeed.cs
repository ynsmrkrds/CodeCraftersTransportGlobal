using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Enums.TransporterContextEnums;

namespace TransportGlobal.Infrastructure.Seeds.TransporterContextSeeds
{
    internal class VehicleSeed : IEntityTypeConfiguration<VehicleEntity>
    {
        public void Configure(EntityTypeBuilder<VehicleEntity> builder)
        {
            VehicleEntity vehicle1 = new(1, "ABC 123", VehicleType.Van, VehicleStatusType.Available)
            {
                ID = 1
            };
            builder.HasData(vehicle1);

            VehicleEntity vehicle2 = new(1, "XYZ 789", VehicleType.Truck, VehicleStatusType.Available)
            {
                ID = 2
            };
            builder.HasData(vehicle2);

            VehicleEntity vehicle3 = new(1, "NY12345", VehicleType.Ship, VehicleStatusType.Available)
            {
                ID = 3
            };
            builder.HasData(vehicle3);

            VehicleEntity vehicle4 = new(1, "BREL-2023", VehicleType.Train, VehicleStatusType.NotWorking)
            {
                ID = 4
            };
            builder.HasData(vehicle4);

            VehicleEntity vehicle5 = new(1, "N387BA", VehicleType.Airplane, VehicleStatusType.NotWorking)
            {
                ID = 5
            };
            builder.HasData(vehicle5);
        }
    }
}
