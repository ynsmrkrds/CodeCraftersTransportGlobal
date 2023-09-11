using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateCompany
{
    public class CreateCompanyCommandRequest : IRequest<CreateCompanyCommandResponse>
    {
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }

        public CreateCompanyCommandRequest(string name, string address, string phoneNumber, string email)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
