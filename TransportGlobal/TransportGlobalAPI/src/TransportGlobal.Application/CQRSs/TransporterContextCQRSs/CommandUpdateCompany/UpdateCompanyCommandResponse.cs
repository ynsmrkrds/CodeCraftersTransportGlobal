using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandUpdateCompany
{
    public class UpdateCompanyCommandResponse : BaseCommandResponseDTO
    {
        public UpdateCompanyCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
