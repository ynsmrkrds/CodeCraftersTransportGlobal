using AutoMapper;
using MediatR;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetAllCompanies;
using TransportGlobal.Application.ViewModels.CompanyContextViewModels;
using TransportGlobal.Domain.Entities.CompanyContextEntities;
using TransportGlobal.Domain.ObjectExtensions;
using TransportGlobal.Domain.Repositories.CompanyContextRepositories;

namespace EventManagement.Application.CQRSs.CategoryContextCQRSs.QueryGetCategory
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQueryRequest, GetAllCompaniesQueryResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public Task<GetAllCompaniesQueryResponse> Handle(GetAllCompaniesQueryRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<CompanyEntity> companies = _companyRepository.GetAll().AsEnumerable();
            companies = companies.WithPagination(request.Pagination);

            List<CompanyViewModel> viewModels = _mapper.Map<List<CompanyEntity>, List<CompanyViewModel>>(companies.ToList());

            return Task.FromResult(new GetAllCompaniesQueryResponse(viewModels));
        }
    }
}
