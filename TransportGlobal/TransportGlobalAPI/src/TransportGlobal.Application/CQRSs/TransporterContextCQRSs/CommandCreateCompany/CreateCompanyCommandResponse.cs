using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateCompany
{
    public class CreateCompanyCommandResponse : BaseCommandResponseDTO
    {
        public CreateCompanyCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
