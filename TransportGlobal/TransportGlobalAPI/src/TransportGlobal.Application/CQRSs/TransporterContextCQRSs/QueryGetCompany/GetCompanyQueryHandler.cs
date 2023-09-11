using AutoMapper;
using MediatR;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetCompany;
using TransportGlobal.Application.ViewModels.TransporterContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;

namespace EventManagement.Application.CQRSs.CategoryContextCQRSs.QueryGetCategory
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQueryRequest, GetCompanyQueryResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public Task<GetCompanyQueryResponse> Handle(GetCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            CompanyEntity companyEntity = _companyRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundCompany);

            CompanyViewModel companyViewModel = _mapper.Map<CompanyEntity, CompanyViewModel>(companyEntity);

            return Task.FromResult(new GetCompanyQueryResponse(companyViewModel));
        }
    }
}
