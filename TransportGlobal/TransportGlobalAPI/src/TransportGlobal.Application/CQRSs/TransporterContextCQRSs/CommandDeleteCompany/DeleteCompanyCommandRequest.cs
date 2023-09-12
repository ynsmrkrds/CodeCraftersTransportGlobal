using MediatR;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandDeleteCompany
{
    public class DeleteCompanyCommandRequest : IRequest<DeleteCompanyCommandResponse>
    {
        public int ID { get; set; }

        public DeleteCompanyCommandRequest(int id)
        {
            ID = id;
        }
    }
}
