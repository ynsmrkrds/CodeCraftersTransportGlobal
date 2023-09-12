using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandDeleteVehicle
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommandRequest, DeleteVehicleCommandResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;

        public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepository, IEmployeeRepository employeeRepository, IUserRepository userRepository)
        {
            _vehicleRepository = vehicleRepository;
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        public Task<DeleteVehicleCommandResponse> Handle(DeleteVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);

            VehicleEntity vehicleEntity = _vehicleRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundVehicle);
            if (vehicleEntity.CompanyID != userEntity.ActiveCompany?.ID) return Task.FromResult(new DeleteVehicleCommandResponse(ResponseConstants.NotVehicleOwner));

            if (vehicleEntity.Employees.Count > 0)
            {
                foreach (EmployeeEntity employee in vehicleEntity.Employees)
                {
                    employee.VehicleID = null;
                }
            }

            vehicleEntity.IsDeleted = true;
            _vehicleRepository.Update(vehicleEntity);

            int effectedRows = _vehicleRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new DeleteVehicleCommandResponse(ResponseConstants.DeleteFailed));

            return Task.FromResult(new DeleteVehicleCommandResponse(ResponseConstants.SuccessfullyDeleted));
        }
    }
}
