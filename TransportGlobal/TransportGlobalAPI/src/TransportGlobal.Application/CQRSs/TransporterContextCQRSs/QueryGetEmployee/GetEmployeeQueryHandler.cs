using AutoMapper;
using MediatR;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetEmployee;
using TransportGlobal.Application.ViewModels.TransporterContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;

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
