using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Enums.TransporterContextEnums;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandUpdateVehicle
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommandRequest, UpdateVehicleCommandResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository, IUserRepository userRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<UpdateVehicleCommandResponse> Handle(UpdateVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Status == VehicleStatusType.AtWork) throw new ClientSideException(ExceptionConstants.CannotUpdateWithValue);

            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);

            VehicleEntity vehicleEntity = _vehicleRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundVehicle);
            if (vehicleEntity.CompanyID != userEntity.ActiveCompany?.ID) return Task.FromResult(new UpdateVehicleCommandResponse(ResponseConstants.NotVehicleOwner));

            if (vehicleEntity.Status == VehicleStatusType.AtWork) return Task.FromResult(new UpdateVehicleCommandResponse(ResponseConstants.VehicleStatusCannotUpdate));

            if (request.Status == VehicleStatusType.Available && _vehicleRepository.CanVehicleWork(vehicleEntity.ID) == false) return Task.FromResult(new UpdateVehicleCommandResponse(ResponseConstants.VehicleCanNotWork));

            _mapper.Map(request, vehicleEntity);
            _vehicleRepository.Update(vehicleEntity);

            int effectedRows = _vehicleRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new UpdateVehicleCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new UpdateVehicleCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
