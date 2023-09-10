using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandDeleteCompany
{
    public class DeleteCompanyCommandResponse : BaseCommandResponseDTO
    {
        public DeleteCompanyCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
