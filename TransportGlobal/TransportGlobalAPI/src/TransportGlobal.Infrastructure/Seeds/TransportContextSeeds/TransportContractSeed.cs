using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Enums.TransportContextEnums;

namespace TransportGlobal.Infrastructure.Seeds.TransportContextSeeds
{
    internal class TransportContractSeed : IEntityTypeConfiguration<TransportContractEntity>
    {
        public void Configure(EntityTypeBuilder<TransportContractEntity> builder)
        {
            TransportContractEntity transportContract1 = new(2, 1, 2, 2, 2000, TransportContractStatusType.NotAgreed)
            {
                ID = 1
            };
            builder.HasData(transportContract1);

            TransportContractEntity transportContract2 = new(2, 1, 2, 2, 1500, TransportContractStatusType.Agreed)
            {
                ID = 2
            };
            builder.HasData(transportContract2);

            TransportContractEntity transportContract3 = new(2, 1, 1, 1, 2500, TransportContractStatusType.Pending)
            {
                ID = 3
            };
            builder.HasData(transportContract3);
        }
    }
}
