using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.CompanyContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.CompanyContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandDeleteVehicle
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommandRequest, DeleteVehicleCommandResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;

        public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepository, IUserRepository userRepository)
        {
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
        }

        public Task<DeleteVehicleCommandResponse> Handle(DeleteVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);

            VehicleEntity vehicleEntity = _vehicleRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundVehicle);
            if (vehicleEntity.CompanyID != userEntity.Company?.ID) return Task.FromResult(new DeleteVehicleCommandResponse(ResponseConstants.NotVehicleOwner));

            _vehicleRepository.Delete(vehicleEntity);

            int effectedRows = _vehicleRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new DeleteVehicleCommandResponse(ResponseConstants.DeleteFailed));

            return Task.FromResult(new DeleteVehicleCommandResponse(ResponseConstants.SuccessfullyDeleted));
        }
    }
}
