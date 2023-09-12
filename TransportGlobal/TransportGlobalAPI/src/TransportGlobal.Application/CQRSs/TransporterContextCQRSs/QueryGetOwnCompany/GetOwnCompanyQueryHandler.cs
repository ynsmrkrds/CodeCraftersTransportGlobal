using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Application.ViewModels.TransporterContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetOwnCompany
{
    public class GetOwnCompanyQueryHandler : IRequestHandler<GetOwnCompanyQueryRequest, GetOwnCompanyQueryResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetOwnCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public Task<GetOwnCompanyQueryResponse> Handle(GetOwnCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);

            CompanyEntity companyEntity = _companyRepository.GetCompanyByUserID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundCompany);

            CompanyViewModel companyViewModel = _mapper.Map<CompanyEntity, CompanyViewModel>(companyEntity);

            return Task.FromResult(new GetOwnCompanyQueryResponse(companyViewModel));
        }
    }
}
