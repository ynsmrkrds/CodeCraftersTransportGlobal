using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Enums.MessagingContextEnums;

namespace TransportGlobal.Infrastructure.Seeds.MessagingContextSeeds
{
    internal class MessageSeed : IEntityTypeConfiguration<MessageEntity>
    {
        public void Configure(EntityTypeBuilder<MessageEntity> builder)
        {
            MessageEntity message1 = new(1, 1, 2, MessageContentType.Contract, "2", DateTime.Now.AddDays(-9).AddMinutes(5).AddSeconds(1))
            {
                ID = 1
            };
            builder.HasData(message1);

            MessageEntity message2 = new(1, 1, 2, MessageContentType.Text, "Our new offer to you is this:", DateTime.Now.AddDays(-9).AddMinutes(5))
            {
                ID = 2
            };
            builder.HasData(message2);

            MessageEntity message3 = new(1, 2, 1, MessageContentType.Text, "Hello. The price is too high, 1500?", DateTime.Now.AddDays(-9).AddMinutes(3))
            {
                ID = 3
            };
            builder.HasData(message3);

            MessageEntity message4 = new(1, 1, 2, MessageContentType.Contract, "1", DateTime.Now.AddDays(-9).AddSeconds(1))
            {
                ID = 4
            };
            builder.HasData(message4);

            MessageEntity message5 = new(1, 1, 2, MessageContentType.Text, "Hello. Here's what we're offering you:", DateTime.Now.AddDays(-9))
            {
                ID = 5
            };
            builder.HasData(message5);

            MessageEntity message6 = new(2, 1, 2, MessageContentType.Contract, "3", DateTime.Now.AddSeconds(1))
            {
                ID = 6
            };
            builder.HasData(message6);

            MessageEntity message7 = new(2, 1, 2, MessageContentType.Text, "Hello. Here's what we're offering you:", DateTime.Now)
            {
                ID = 7
            };
            builder.HasData(message7);
        }
    }
}
