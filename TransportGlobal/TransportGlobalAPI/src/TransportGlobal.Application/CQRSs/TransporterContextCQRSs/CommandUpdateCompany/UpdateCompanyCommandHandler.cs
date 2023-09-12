using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandUpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, UpdateCompanyCommandResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public Task<UpdateCompanyCommandResponse> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);

            CompanyEntity companyEntity = _companyRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundCompany);
            if (companyEntity.IsDeleted) throw new ClientSideException(ExceptionConstants.NotFoundCompany);

            if (companyEntity.OwnerUserID != userID) return Task.FromResult(new UpdateCompanyCommandResponse(ResponseConstants.NotCompanyOwner));

            _mapper.Map(request, companyEntity);
            _companyRepository.Update(companyEntity);

            int effectedRows = _companyRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new UpdateCompanyCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new UpdateCompanyCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
