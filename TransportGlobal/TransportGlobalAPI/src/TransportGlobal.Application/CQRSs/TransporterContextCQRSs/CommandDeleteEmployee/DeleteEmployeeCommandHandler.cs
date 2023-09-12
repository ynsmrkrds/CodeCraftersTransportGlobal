using MediatR;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandDeleteEmployee;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.CommandDeleteLocation
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommandRequest, DeleteEmployeeCommandResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUserRepository userRepository, IVehicleRepository vehicleRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            _vehicleRepository = vehicleRepository;
        }

        public Task<DeleteEmployeeCommandResponse> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);

            EmployeeEntity employeeEntity = _employeeRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundEmployee);
            if (employeeEntity.IsDeleted) throw new ClientSideException(ExceptionConstants.NotFoundEmployee);

            if (employeeEntity.CompanyID != userEntity.ActiveCompany?.ID) return Task.FromResult(new DeleteEmployeeCommandResponse(ResponseConstants.NotEmployeeOwner));

            employeeEntity.IsDeleted = true;
            _employeeRepository.Update(employeeEntity);

            int effectedRows = _employeeRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new DeleteEmployeeCommandResponse(ResponseConstants.DeleteFailed));

            if (employeeEntity.VehicleID != null)
            {
                _vehicleRepository.OnVehicleEmployeesChanged((int)employeeEntity.VehicleID);
            }

            return Task.FromResult(new DeleteEmployeeCommandResponse(ResponseConstants.SuccessfullyDeleted));
        }
    }
}
