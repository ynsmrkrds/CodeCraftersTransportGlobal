using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.CompanyContextEntities
{
    public class CompanyEntity : BaseEntity
    {
        [ForeignKey(nameof(OwnerUser))]
        public int OwnerUserID { get; set; }

        public UserEntity? OwnerUser { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<VehicleEntity> Vehicles { get; set; } = new List<VehicleEntity>();

        public ICollection<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();

        public CompanyEntity(string name, string address, string phoneNumber, string email, bool isDeleted = false)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            IsDeleted = isDeleted;
        }
    }
}