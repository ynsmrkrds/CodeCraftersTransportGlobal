using AutoMapper;
using MediatR;
using TransportGlobal.Application.ViewModels.TransporterContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetVehicle
{
    public class GetVehicleQueryHandler : IRequestHandler<GetVehicleQueryRequest, GetVehicleQueryResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public GetVehicleQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public Task<GetVehicleQueryResponse> Handle(GetVehicleQueryRequest request, CancellationToken cancellationToken)
        {
            VehicleEntity vehicleEntity = _vehicleRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundVehicle);

            VehicleViewModel vehicleViewModel = _mapper.Map<VehicleEntity, VehicleViewModel>(vehicleEntity);

            return Task.FromResult(new GetVehicleQueryResponse(vehicleViewModel));
        }
    }
}
