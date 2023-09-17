using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Enums.UserContextEnums;

namespace TransportGlobal.Infrastructure.Seeds.UserContextSeeds
{
    internal class UserSeed : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            string passwordHash = "wEXC+zsV9xjSjrlsyqK58SjE3IasyI327aF25jotP7/98elqf/+cd+KzKDv2PSPBaeSE0/8cPOnOJYtkZ3y1Eg=="; // 123456
            
            UserEntity shipperUser = new("John", "Doe", "john.doe@gmail.com", passwordHash, UserType.Shipper)
            {
                ID = 1
            };
            builder.HasData(shipperUser);

            UserEntity customerUser = new("Mark", "Smith", "mark.smith@gmail.com", passwordHash, UserType.Customer)
            {
                ID = 2
            };
            builder.HasData(customerUser);
        }
    }
}
