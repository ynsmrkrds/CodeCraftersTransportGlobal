using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportGlobal.Domain.Entities.TransporterContextEntities;

namespace TransportGlobal.Infrastructure.Seeds.TransporterContextSeeds
{
    internal class CompanySeed : IEntityTypeConfiguration<CompanyEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            CompanyEntity company = new(1, "TransLogistics, LLC", "123 Main Street", "(555) 123-4567", "info@translogistics.com")
            {
                ID = 1
            };
            builder.HasData(company);
        }
    }
}
