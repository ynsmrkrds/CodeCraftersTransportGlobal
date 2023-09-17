using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Enums.TransporterContextEnums;

namespace TransportGlobal.Infrastructure.Seeds.TransporterContextSeeds
{
    internal class EmployeeSeed : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            EmployeeEntity employee1 = new(1, 1, "Tommy", "Hudson", "tommy.hudson@gmail.com", EmployeeTitle.Driver)
            {
                ID = 1
            };
            builder.HasData(employee1);

            EmployeeEntity employee2 = new(1, 1, "Jane", "Smith", "jane.smith@gmail.com", EmployeeTitle.LoadingUnloadingOperator)
            {
                ID = 2
            };
            builder.HasData(employee2);

            EmployeeEntity employee3 = new(1, 1, "Michael", "Johnson", "michael.johnson@gmail.com", EmployeeTitle.TransportationCoordinator)
            {
                ID = 3
            };
            builder.HasData(employee3);

            EmployeeEntity employee4 = new(1, 2, "Emily", "Wilson", "emily.wilson@gmail.com", EmployeeTitle.Driver)
            {
                ID = 4
            };
            builder.HasData(employee4);

            EmployeeEntity employee5 = new(1, 2, "William", "Brown", "william.brown@gmail.com", EmployeeTitle.LoadingUnloadingOperator)
            {
                ID = 5
            };
            builder.HasData(employee5);

            EmployeeEntity employee6 = new(1, 3, "Olivia", "Davis", "olivia.davis@gmail.com", EmployeeTitle.Driver)
            {
                ID = 6
            };
            builder.HasData(employee6);

            EmployeeEntity employee7 = new(1, 3, "James", "Lee", "james.lee@gmail.com", EmployeeTitle.LoadingUnloadingOperator)
            {
                ID = 7
            };
            builder.HasData(employee7);

            EmployeeEntity employee8 = new(1, 3, "Sophia", "Clark", "sophia.clark@gmail.com", EmployeeTitle.LoadingUnloadingOperator)
            {
                ID = 8
            };
            builder.HasData(employee8);

            EmployeeEntity employee9 = new(1, 3, "Liam", "Hall", "liam.hall@gmail.com", EmployeeTitle.TransportationCoordinator)
            {
                ID = 9
            };
            builder.HasData(employee9);

            EmployeeEntity employee10 = new(1, 4, "Ava", "White", "ava.white@gmail.com", EmployeeTitle.Driver)
            {
                ID = 10
            };
            builder.HasData(employee10);
        }
    }
}
