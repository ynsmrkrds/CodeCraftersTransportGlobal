using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Application.ViewModels.TransporterContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.ObjectExtensions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetOwnEmployees
{
    public class GetOwnEmployeesQueryHandler : IRequestHandler<GetOwnEmployeesQueryRequest, GetOwnEmployeesQueryResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetOwnEmployeesQueryHandler(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public Task<GetOwnEmployeesQueryResponse> Handle(GetOwnEmployeesQueryRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);

            CompanyEntity companyEntity = _companyRepository.GetCompanyByUserID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundCompany);

            IEnumerable<EmployeeEntity> employees = _employeeRepository.GetAllByCompanyID(companyEntity.ID);

            IEnumerable<EmployeeViewModel> viewModels = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);

            return Task.FromResult(new GetOwnEmployeesQueryResponse(viewModels, request.Pagination));
        }
    }
}
