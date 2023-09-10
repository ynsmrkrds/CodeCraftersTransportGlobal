using AutoMapper;
using MediatR;
using TransportGlobal.Application.ViewModels.CompanyContextViewModels;
using TransportGlobal.Domain.Entities.CompanyContextEntities;
using TransportGlobal.Domain.ObjectExtensions;
using TransportGlobal.Domain.Repositories.CompanyContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQueryRequest, GetAllEmployeesQueryResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository, IUserRepository userRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<GetAllEmployeesQueryResponse> Handle(GetAllEmployeesQueryRequest request, CancellationToken cancellationToken)
        {
            List<EmployeeEntity> employees;

            if (request.CompanyID != null)
            {
                employees = _employeeRepository.GetAllByCompanyID((int)request.CompanyID).WithPagination(request.Pagination).ToList();
            }
            else if (request.VehicleID != null)
            {
                employees = _employeeRepository.GetAllByVehicleID((int)request.VehicleID).WithPagination(request.Pagination).ToList();
            }
            else
            {
                employees = _employeeRepository.GetAll().AsEnumerable().WithPagination(request.Pagination).ToList();
            }

            List<EmployeeViewModel> viewModels = _mapper.Map<List<EmployeeEntity>, List<EmployeeViewModel>>(employees);

            return Task.FromResult(new GetAllEmployeesQueryResponse(viewModels));

        }
    }
}
