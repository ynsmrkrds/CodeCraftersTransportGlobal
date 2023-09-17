using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportGlobal.Domain.Entities.MessagingContextEntities;

namespace TransportGlobal.Infrastructure.Seeds.MessagingContextSeeds
{
    internal class ChatSeed : IEntityTypeConfiguration<ChatEntity>
    {
        public void Configure(EntityTypeBuilder<ChatEntity> builder)
        {
            ChatEntity chat1 = new(2, 1, 2)
            {
                ID = 1
            };
            builder.HasData(chat1);

            ChatEntity chat2 = new(1, 1, 2)
            {
                ID = 2
            };
            builder.HasData(chat2);
        }
    }
}
