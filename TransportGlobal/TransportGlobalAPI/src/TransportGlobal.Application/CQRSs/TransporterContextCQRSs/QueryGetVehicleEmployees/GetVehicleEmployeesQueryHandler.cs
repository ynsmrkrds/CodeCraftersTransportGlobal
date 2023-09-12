using AutoMapper;
using MediatR;
using TransportGlobal.Application.ViewModels.TransporterContextViewModels;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.ObjectExtensions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetVehicleEmployees
{
    public class GetVehicleEmployeesQueryHandler : IRequestHandler<GetVehicleEmployeesQueryRequest, GetVehicleEmployeesQueryResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetVehicleEmployeesQueryHandler(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public Task<GetVehicleEmployeesQueryResponse> Handle(GetVehicleEmployeesQueryRequest request, CancellationToken cancellationToken)
        {
            List<EmployeeEntity> employees = _employeeRepository.GetAllByVehicleID(request.VehicleID).WithPagination(request.Pagination).ToList();

            List<EmployeeViewModel> viewModels = _mapper.Map<List<EmployeeEntity>, List<EmployeeViewModel>>(employees);

            return Task.FromResult(new GetVehicleEmployeesQueryResponse(viewModels));
        }
    }
}
