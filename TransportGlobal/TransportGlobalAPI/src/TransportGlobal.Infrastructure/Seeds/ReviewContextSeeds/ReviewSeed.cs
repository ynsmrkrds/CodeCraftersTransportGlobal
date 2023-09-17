using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportGlobal.Domain.Entities.ReviewContextEntities;

namespace TransportGlobal.Infrastructure.Seeds.ReviewContextSeeds
{
    internal class ReviewSeed : IEntityTypeConfiguration<ReviewEntity>
    {
        public void Configure(EntityTypeBuilder<ReviewEntity> builder)
        {
            ReviewEntity review = new(1, 5, "Great shipping service, arrived on time!")
            {
                ID = 1
            };
            builder.HasData(review);
        }
    }
}
