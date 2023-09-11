using AutoMapper;
using MediatR;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateEmployee;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandUpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUserRepository userRepository, IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);

            EmployeeEntity employeeEntity = _employeeRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundEmployee);
            if (employeeEntity.CompanyID != userEntity.ActiveCompany?.ID) return Task.FromResult(new UpdateEmployeeCommandResponse(ResponseConstants.NotVehicleOwner));

            if (employeeEntity.Email != request.Email && _userRepository.IsExistsWithSameEmail(request.Email)) return Task.FromResult(new UpdateEmployeeCommandResponse(ResponseConstants.ExistsEmployeeWithSameEmail));

            if (request.VehicleID != null && _vehicleRepository.IsVehicleAtWork((int)request.VehicleID) == true) return Task.FromResult(new UpdateEmployeeCommandResponse(ResponseConstants.EmployeeCannotAssignToVehicle));

            _mapper.Map(request, employeeEntity);
            _employeeRepository.Update(employeeEntity);

            int effectedRows = _employeeRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new UpdateEmployeeCommandResponse(ResponseConstants.UpdateFailed));

            if (request.VehicleID != null)
            {
                _vehicleRepository.OnVehicleEmployeesChanged((int)request.VehicleID);
            }

            return Task.FromResult(new UpdateEmployeeCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
