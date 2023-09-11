using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, CreateCompanyCommandResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IUserRepository userRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            if (_userRepository.HasCompany(userID)) return Task.FromResult(new CreateCompanyCommandResponse(ResponseConstants.UserHasCompany));

            if (_companyRepository.IsExistsWithSameEmail(request.Email)) return Task.FromResult(new CreateCompanyCommandResponse(ResponseConstants.ExistsCompanyWithSameEmail));

            CompanyEntity companyEntity = _mapper.Map<CompanyEntity>(request);
            companyEntity.OwnerUserID = userID;
            _companyRepository.Add(companyEntity);

            int effectedRows = _companyRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateCompanyCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateCompanyCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
