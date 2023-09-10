using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandUpdateCompany
{
    public class UpdateCompanyCommandResponse : BaseCommandResponseDTO
    {
        public UpdateCompanyCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
