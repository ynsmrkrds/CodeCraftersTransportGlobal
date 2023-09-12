using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandDeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommandRequest, DeleteCompanyCommandResponse>
    {
        private readonly ICompanyRepository _companyRepository;

        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Task<DeleteCompanyCommandResponse> Handle(DeleteCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);

            CompanyEntity companyEntity = _companyRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundCompany);
            if (companyEntity.OwnerUserID != userID) return Task.FromResult(new DeleteCompanyCommandResponse(ResponseConstants.NotCompanyOwner));

            companyEntity.IsDeleted = true;
            _companyRepository.Update(companyEntity);

            int effectedRows = _companyRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new DeleteCompanyCommandResponse(ResponseConstants.DeleteFailed));

            return Task.FromResult(new DeleteCompanyCommandResponse(ResponseConstants.SuccessfullyDeleted));
        }
    }
}
