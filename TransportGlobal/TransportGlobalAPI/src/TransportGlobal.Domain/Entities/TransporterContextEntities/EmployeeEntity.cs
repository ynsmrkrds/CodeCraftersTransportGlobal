using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TransportGlobal.Domain.Enums.TransporterContextEnums;
using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.TransporterContextEntities
{
    public class EmployeeEntity : BaseEntity
    {
        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }

        public CompanyEntity? Company { get; set; }

        [ForeignKey(nameof(Vehicle))]
        public int? VehicleID { get; set; }

        public VehicleEntity? Vehicle { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }

        public EmployeeTitle Title { get; set; }

        public bool IsDeleted { get; set; }

        public EmployeeEntity(int companyID, int? vehicleID, string name, string surname, string email, EmployeeTitle title, bool isDeleted)
        {
            CompanyID = companyID;
            VehicleID = vehicleID;
            Name = name;
            Surname = surname;
            Email = email;
            Title = title;
            IsDeleted = isDeleted;
        }
    }
}
