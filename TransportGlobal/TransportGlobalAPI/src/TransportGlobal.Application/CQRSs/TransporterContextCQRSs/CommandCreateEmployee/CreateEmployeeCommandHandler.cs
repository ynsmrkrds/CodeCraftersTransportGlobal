using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest, CreateEmployeeCommandResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IVehicleRepository vehicleRepository, IUserRepository userRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);

            if (_userRepository.HasCompany(userID) == false) return Task.FromResult(new CreateEmployeeCommandResponse(ResponseConstants.UserHasNotCompany));

            if (_employeeRepository.IsExistsWithSameEmail(request.Email)) return Task.FromResult(new CreateEmployeeCommandResponse(ResponseConstants.ExistsEmployeeWithSameEmail));

            if (request.VehicleID != null && _vehicleRepository.IsVehicleAtWork((int)request.VehicleID) == true) return Task.FromResult(new CreateEmployeeCommandResponse(ResponseConstants.EmployeeCannotAssignToVehicle));

            EmployeeEntity employeeEntity = _mapper.Map<EmployeeEntity>(request);
            employeeEntity.CompanyID = userEntity.ActiveCompany!.ID;

            _employeeRepository.Add(employeeEntity);

            int effectedRows = _employeeRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateEmployeeCommandResponse(ResponseConstants.CreateFailed));

            if (request.VehicleID != null)
            {
                _vehicleRepository.OnVehicleEmployeesChanged((int)request.VehicleID);
            }

            return Task.FromResult(new CreateEmployeeCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
