using System.ComponentModel.DataAnnotations;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Enums.UserContextEnums;
using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.UserContextEntities
{
    public class UserEntity : BaseEntity
    {
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public UserType Type { get; set; }

        public ICollection<CompanyEntity> Companies { get; set; } = new List<CompanyEntity>();

        public ICollection<TransportContractEntity> TransportContracts { get; set; } = new List<TransportContractEntity>();

        public ICollection<ChatEntity> SenderUserChats { get; set; } = new List<ChatEntity>();

        public ICollection<ChatEntity> ReceiverUserChats { get; set; } = new List<ChatEntity>();

        public UserEntity(string name, string surname, string email, string passwordHash, UserType type)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PasswordHash = passwordHash;
            Type = type;
        }

        public CompanyEntity? ActiveCompany => Companies.FirstOrDefault(x => x.IsDeleted == false);
    }
}
