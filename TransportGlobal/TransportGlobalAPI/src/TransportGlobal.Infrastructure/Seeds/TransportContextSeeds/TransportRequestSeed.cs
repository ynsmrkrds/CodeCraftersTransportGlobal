using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Enums.TransportContextEnums;

namespace TransportGlobal.Infrastructure.Seeds.TransportContextSeeds
{
    internal class TransportRequestSeed : IEntityTypeConfiguration<TransportRequestEntity>
    {
        public void Configure(EntityTypeBuilder<TransportRequestEntity> builder)
        {
            TransportRequestEntity transportRequest1 = new(2, TransportType.WhiteGoods, 500.5, 1000.0, DateTime.Now.AddDays(7), "123 Main Street, New York", "456 Elm Street, Los Angeles", TransportRequestStatusType.Pending)
            {
                ID = 1
            };
            builder.HasData(transportRequest1);

            TransportRequestEntity transportRequest2 = new(2, TransportType.AntiqueFurniture, 1000.0, 2000.0, DateTime.Now.AddDays(-7), "789 Oak Avenue, Chicago", "101 Pine Road, Miami", TransportRequestStatusType.Done)
            {
                ID = 2
            };
            builder.HasData(transportRequest2);
        }
    }
}
