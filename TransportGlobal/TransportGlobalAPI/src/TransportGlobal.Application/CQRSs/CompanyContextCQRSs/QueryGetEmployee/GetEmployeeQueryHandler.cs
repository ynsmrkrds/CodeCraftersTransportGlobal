using AutoMapper;
using MediatR;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetEmployee;
using TransportGlobal.Application.ViewModels.CompanyContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.CompanyContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.CompanyContextRepositories;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.QueryGetAllLocations
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQueryRequest, GetEmployeeQueryResponse>
    {
        private readonly IEmployeeRepository _employeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeQueryHandler(IEmployeeRepository employeRepository, IMapper mapper)
        {
            _employeRepository = employeRepository;
            _mapper = mapper;
        }

        public Task<GetEmployeeQueryResponse> Handle(GetEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            EmployeeEntity employeeEntity = _employeRepository.GetByID(request.ID) ?? throw new ClientSideException(ResponseConstants.NotVehicleOwner.Message);

            EmployeeViewModel employeeViewModel = _mapper.Map<EmployeeEntity, EmployeeViewModel>(employeeEntity);

            return Task.FromResult(new GetEmployeeQueryResponse(employeeViewModel));
        }
    }
}
