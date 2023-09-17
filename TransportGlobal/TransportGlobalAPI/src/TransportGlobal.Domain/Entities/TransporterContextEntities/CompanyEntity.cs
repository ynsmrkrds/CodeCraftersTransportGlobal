using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.TransporterContextEntities
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

        public ICollection<VehicleEntity> Vehicles { get; set; } = new List<VehicleEntity>();

        public ICollection<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();

        public ICollection<TransportContractEntity> TransportContracts { get; set; } = new List<TransportContractEntity>();

        public CompanyEntity(string name, string address, string phoneNumber, string email, bool isDeleted = false)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            IsDeleted = isDeleted;
        }

        public CompanyEntity(int ownerUserID, string name, string address, string phoneNumber, string email, bool isDeleted = false)
        {
            OwnerUserID = ownerUserID;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            IsDeleted = isDeleted;
        }
    }
}